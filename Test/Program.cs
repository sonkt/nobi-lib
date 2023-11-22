using GbLib.Repositories;
using Test;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapGet("/pageddata", async (ITestService testService) =>
{
    using (var trans = testService.GetDbTransaction())
    {
        var dictSort = new Dictionary<string, bool>();
        dictSort.Add("TestCode", false);
        var data = await testService.FindPagedAsync(1,10,m => m.TestCode.Contains("B"), dictSort, trans);
        return Results.Ok(data);
    }
})
.WithName("PagedData")
.WithOpenApi();

app.MapGet("/countdata", async (ITestService testService) =>
{
    using (var trans = testService.GetDbTransaction())
    {
        var data = await testService.QueryAsync<int>("Select Count(*) as NumberOfRow From TestEntities",null, trans);
        return Results.Ok(data.FirstOrDefault());
    }
})
.WithName("CountData")
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}