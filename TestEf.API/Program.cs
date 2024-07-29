using GbLib.Base;
using GbLib.Ef.Repositories;
using GbLib.Jwt;
using GbLib.Swagger;
using TestEf.Application;
using GbLib.RabbitMQ;
using Autofac;
using Autofac.Extensions.DependencyInjection;

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
            builder.Services.ScopedByPosfix<ITestEfService>("Service");
            builder.Services.SingletonByPosfix<TestEventHandler>("EventHandler");
            builder.Services.AddHostedService<TestWorker>();
            builder.Services.AddRabbitConfig<FirstRabbitConfig>("RabbitConfiguration:FirstRabbit");
            builder.Services.AddRabbitConfig<SecondRabbitConfig>("RabbitConfiguration:SecondRabbit");

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(container => { 
                container.RegisterRabbitPublisher<FirstRabbitConfig>();
                container.RegisterRabbitSubcriber<FirstRabbitConfig>();
                container.RegisterRabbitSubcriber<SecondRabbitConfig>();
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.RabbitSubcriber<FirstRabbitConfig>().SubscribeEvent<TestEvent>();
            app.RabbitSubcriber<SecondRabbitConfig>().SubscribeEvent<TestEvent>();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseAuthentication();
            app.MapControllers();

            app.Run();
        }
    }
}