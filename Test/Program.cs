using Autofac;
using Autofac.Extensions.DependencyInjection;
using Dapper;
using GbLib.Base;
using GbLib.Jwt;
using GbLib.Kafka;
using GbLib.Repositories;
using GbLib.RMQ;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Security.Claims;
using Test.Application;
using Test.Application.RabbitMqEvent;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddJwt();
builder.Services.AddRabbitMq(builder.Configuration);
builder.Services.AddBusKafkaConfig();
builder.Services.AddSingleton<ICorrelationContext, CorrelationContext>();
builder.Services.AddDapperOrmRepository<TestDbContext>();
builder.Services.Scan(scan => scan
           .FromAssemblyOf<ITestService>()
                .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
                   .AsImplementedInterfaces()
                   .WithScopedLifetime());
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        var assembly = typeof(TestEntity).GetTypeInfo().Assembly;
        builder.BuildContainerKafkaEventBus(assembly);
        builder.UseRabbitMq(assembly);
        builder.RegisterAssemblyTypes(assembly)
            .AsClosedTypesOf(typeof(ICommandHandler<>))
            .InstancePerLifetimeScope();
    });
builder.Services.AddSingleton<RabbitSender<TestEvent>>();
builder.Services.AddHostedService<RabbitReceiver<TestEvent>>();
builder.Services.AddSingleton<RabbitSender<PingEvent>>();
builder.Services.AddHostedService<RabbitReceiver<PingEvent>>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseAuthentication();
    app.UseAuthorization();
}
app.KafkaEventBusSubcriber().ConsumeEvent<KafkaTestEvent>();
app.UseHttpsRedirection();

app.MapGet("/all/{keyword}", async ([FromRoute] string keyword, ITestService testService) =>
{
    using (var trans = testService.GetDbTransaction())
    {
        var dictSort = new Dictionary<string, bool>();
        dictSort.Add("TestCode", false);
        var data = await testService.FindPagedAsync(1, 10, m => m.TestCode.Contains(keyword) && m.IsDeleted != true, dictSort, trans);
        return Results.Ok(data);
    }
})
.WithName("SearchData")
.WithOpenApi();

app.MapGet("/countdata", async (ITestService testService) =>
{
    using (var trans = testService.GetDbTransaction())
    {
        var data = await testService.QueryAsync<int>("Select Count(*) as NumberOfRow From TestEntities", null, trans);
        return Results.Ok(data.FirstOrDefault());
    }
})
.WithName("CountData")
.WithOpenApi();

app.MapPut("/updatedata/{code}/{newName}", ([FromRoute] string code, [FromRoute] string newName, ITestService testService) =>
{
    using (var trans = testService.GetDbTransaction())
    {
        var data = testService.Find(m => m.TestCode == code, trans);
        if (data != null)
        {
            data.TestName = newName;
            var updateResult = testService.Update(data, trans);
            trans.Commit();
            return Task.FromResult(Results.Ok(updateResult));
        }
        return Task.FromResult(Results.NoContent());
    }
})
.WithName("UpdateData")
.WithOpenApi();

app.MapGet("/all/{column}/{isDesc}", async ([FromRoute] string column, [FromRoute] bool isDesc, ITestService testService) =>
{
    using (var trans = testService.GetDbTransaction())
    {
        var dictSort = new Dictionary<string, bool>();
        dictSort.Add(column, isDesc);
        var data = await testService.FindAllAsync(m => m.IsDeleted == false, dictSort, trans);
        return Results.Ok(data);
    }
})  
.WithName("AllData")
.WithOpenApi();

app.MapGet("/alldata/{numOfRows}/{column}/{isDesc}", async ([FromRoute] int numOfRows, [FromRoute] string column, [FromRoute] bool isDesc, ITestService testService) =>
{
    using (var trans = testService.GetDbTransaction())
    {
        var dictSort = new Dictionary<string, bool>();
        dictSort.Add(column, isDesc);
        var data = await testService.FindAllAsync(m => m.IsDeleted == false, dictSort, numOfRows, trans);
        return Results.Ok(data);
    }
})
.WithName("PagedData")
.WithOpenApi();

app.MapGet("/alldata/{numOfRows}", async ([FromRoute] int numOfRows, ITestService testService) =>
{
    using (var trans = testService.GetDbTransaction())
    {
        var data = await testService.FindAllAsync(m => m.IsDeleted == false, null, numOfRows, trans);
        return Results.Ok(data);
    }
})
.WithName("AllDataNotColumn")
.WithOpenApi();

app.MapPost("/", async ([FromBody] TestModel model, ITestService testService) =>
{
    using (var trans = testService.GetDbTransaction())
    {
        var insertResult = await testService.InsertAsync(new TestEntity
        {
            TestCode = model.TestCode,
            TestName = model.TestName
        }, trans);
        if (insertResult)
        {
            trans.Commit();
            return Results.Ok("Insert thành công");
        }
        else
        {
            trans.Rollback();
            return Results.Ok("Insert fail cmnr");
        }
    }
})
.WithName("InsertData")
.WithOpenApi();

app.MapDelete("/{code}", async ([FromRoute] string code, ITestService testService) =>
{
    using (var trans = testService.GetDbTransaction())
    {
        var entity = await testService.FindAsync(m => m.TestCode == code, trans);
        var insertResult = await testService.DeleteAsync(entity, trans, TimeSpan.FromSeconds(10));
        if (insertResult)
        {
            trans.Commit();
            return Results.Ok("Xóa thành công");
        }
        else
        {
            trans.Rollback();
            return Results.Ok("Xóa fail cmnr");
        }
    }
})
.WithName("DeleteData")
.WithOpenApi();

app.MapGet("/token/{user}", ([FromRoute] string user, IJwtService jwtService) =>
{
    var permissions = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    var claims = new List<Claim> {
        new Claim(JwtClaimsTypes.UserName, user),
        new Claim(JwtClaimsTypes.Role,"Manager")
    };
    foreach (var permission in permissions)
    {
        claims.Add(new Claim(JwtClaimsTypes.Permissions, $"{permission}"));
    }
    var token = jwtService.GenerateAccessToken(claims);
    var rfToken = jwtService.GenerateRefreshToken();
    return Results.Ok(new
    {
        Token = token,
        RefreshToken = rfToken
    });
})
.WithName("Token")
.WithOpenApi();

app.MapGet("/refresh-token/{accessToken}/{refreshToken}", [Auth] ([FromRoute] string accessToken, [FromRoute] string refreshToken, IJwtService jwtService, HttpContext httpContext) =>
{
    var oldToken = httpContext.GetToken();
    var principal = jwtService.GetPrincipalFromToken(oldToken);
    var username = httpContext.GetClaims(JwtClaimsTypes.UserName) ?? new List<string> { };
    var permissions = jwtService.GetClaims(principal, JwtClaimsTypes.Permissions);
    var token = jwtService.GenerateAccessToken(principal.Claims);
    var rfToken = jwtService.GenerateRefreshToken();

    return Results.Ok(new
    {
        Token = token,
        RefreshToken = rfToken
    });
})
.WithName("RefreshToken")
.WithOpenApi();

app.MapGet("/validate-token", [Auth] (HttpContext httpContext) =>
{
    var isValid = httpContext.TokenIsValid();

    return Results.Ok(isValid);
})
.RequireAuthorization()
.WithName("ValidToken")
.WithOpenApi();

app.MapPost("/insert/{code}/{name}", async ([FromRoute] string code, [FromRoute] string name, ITestService testService) =>
{
    using (var trans = testService.GetDbTransaction())
    {
        var parameters = new DynamicParameters();
        parameters.Add("@code", code, System.Data.DbType.String, System.Data.ParameterDirection.Input);
        parameters.Add("@name", name, System.Data.DbType.String, System.Data.ParameterDirection.Input);

        var result = await testService.ExecuteAsync("InsertData", parameters, trans, 100, System.Data.CommandType.StoredProcedure);
        trans.Commit();
        return Results.Ok(new
        {
            Result = result
        });
    }
})
.WithName("Insert")
.WithOpenApi();

app.MapPost("/rabbit", ([FromBody] TestEvent _event, RabbitSender<TestEvent> _rbSender) =>
{
    _rbSender.PublishAsync(_event);
    return Results.Ok("Ok");
})
.WithName("RabbitTest")
.WithOpenApi();


app.MapPost("/rabbit/ping", ([FromBody] PingEvent _event, RabbitSender<PingEvent> _rbSender) =>
{
    _rbSender.PublishAsync(_event);
    return Results.Ok("Ok");
})
.WithName("RabbitPingTest")
.WithOpenApi();


app.MapPost("/kafka/ping", ([FromBody] KafkaTestEvent _event, KafkaPublisher _kkSender) =>
{
    _=_kkSender.PublishAsync(_event);
    return Results.Ok("Ok");
})
.WithName("KafkaPingTest")
.WithOpenApi();

app.Run();