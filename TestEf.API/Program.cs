
using Autofac.Core;
using GbLib.Ef.Repositories;
using TestEf.Application;

namespace TestEf.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<TestEfDbContext>("SqlServer");
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork<TestEfDbContext>>();
            builder.Services.AddAllRepositories<TestEfDbContext>();
            builder.Services.Scan(scan => scan
                       .FromAssemblyOf<ITestEfService>()
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

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
