
using GbLib.Jwt;
using GbLib.Ef.Repositories;
using TestEf.Application;
using GbLib.Swagger;
using GbLib.Base;

namespace TestEf.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddJwt();
            builder.Services.AddCustomMvc();
            builder.Services.AddSwagger();
            builder.Services.AddDbContext<TestEfDbContext>("SqlServer");
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork<TestEfDbContext>>();
            builder.Services.AddAllRepositories<TestEfDbContext>();
            builder.Services.Scan(scan => scan
                       .FromAssemblyOf<ITestEfService>()
                            .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
                               .AsImplementedInterfaces()
                               .WithScopedLifetime());

            builder.Services.AddHostedService<TestWorker>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseAuthentication();
            app.MapControllers();

            app.Run();
        }
    }
}
