using GbLib.Jwt;
using GbLib.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Test;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddJwt();
builder.Services.AddDapperOrmRepository<TestDbContext>();
builder.Services.Scan(scan => scan
           .FromAssemblyOf<ITestService>()
                .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
                   .AsImplementedInterfaces()
                   .WithScopedLifetime());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/pageddata/{keyword}", async ([FromRoute] string keyword, ITestService testService) =>
{
    using (var trans = testService.GetDbTransaction())
    {
        var dictSort = new Dictionary<string, bool>();
        dictSort.Add("TestCode", false);
        var data = await testService.FindPagedAsync(1, 10, m => m.TestCode.Contains(keyword), dictSort, trans);
        return Results.Ok(data);
    }
})
.WithName("PagedData")
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

app.MapPut("/updatedata/{code}/{newName}", async ([FromRoute] string code, [FromRoute] string newName, ITestService testService) =>
{
    using (var trans = testService.GetDbTransaction())
    {
        var data = testService.Find(m => m.TestCode == code, trans);
        if (data != null)
        {
            data.TestName = newName;
            var updateResult = testService.Update(data, trans);
            trans.Commit();
            return Results.Ok(updateResult);
        }
        return Results.NoContent();
    }
})
.WithName("UpdateData")
.WithOpenApi();

app.MapGet("/alldata/{numOfRows}/{column}/{isDesc}", async ([FromRoute] int numOfRows, [FromRoute] string column, [FromRoute] bool isDesc, ITestService testService) =>
{
    using (var trans = testService.GetDbTransaction())
    {
        var dictSort = new Dictionary<string, bool>();
        dictSort.Add(column, isDesc);
        var data = await testService.FindAllAsync(m => m.IsDeleted == null, dictSort, numOfRows, trans);
        return Results.Ok(data);
    }
})
.WithName("AllData")
.WithOpenApi();

app.MapGet("/alldata/{numOfRows}", async ([FromRoute] int numOfRows, ITestService testService) =>
{
    using (var trans = testService.GetDbTransaction())
    {
        var data = await testService.FindAllAsync(m => m.IsDeleted == null, null, numOfRows, trans);
        return Results.Ok(data);
    }
})
.WithName("AllDataNotColumn")
.WithOpenApi();

app.MapGet("/alldata/{column}/{isDesc}", async ([FromRoute] string column, [FromRoute] bool isDesc, ITestService testService) =>
{
    using (var trans = testService.GetDbTransaction())
    {
        var dictSort = new Dictionary<string, bool>();
        dictSort.Add(column, isDesc);
        var data = await testService.FindAllAsync(m => m.IsDeleted == null, dictSort, null, trans);
        return Results.Ok(data);
    }
})
.WithName("AllDataNotNumOfRows")
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
        var insertResult = await testService.DeleteAsync(m => m.TestCode == code, trans, TimeSpan.FromSeconds(10));
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
    var permissions = new int[] {1,2,3,4,5,6,7,8,9};
    var claims = new List<Claim> {
        new Claim(JwtClaimsTypes.UserName, user),
        new Claim(JwtClaimsTypes.Role,"Manager")
    };
    foreach (var permission in permissions)
    {
        claims.Add(new Claim(JwtClaimsTypes.Permissions,$"{permission}"));
    }
    var token = jwtService.GenerateAccessToken(claims);
    var rfToken = jwtService.GenerateRefreshToken();
    return Results.Ok(new { 
        Token= token,
        RefreshToken = rfToken
    });
})
.WithName("Token")
.WithOpenApi();

app.MapGet("/refresh-token/{accessToken}/{refreshToken}", ([FromRoute] string accessToken, [FromRoute] string refreshToken, IJwtService jwtService, HttpContext httpContext) =>
{
    var principal = jwtService.GetPrincipalFromExpiredToken(accessToken);
    var username = httpContext.GetClaim(JwtClaimsTypes.UserName)??"";

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

app.Run();