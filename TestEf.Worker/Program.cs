using TestEf.Application;
using GbLib.RabbitMQ;
using GbLib.Base;
using Autofac.Extensions.DependencyInjection;

namespace TestEf.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddHostedService<Worker>();
            builder.Services.SingletonByPosfix<TestEvent>("EventHandler");
            builder.Services.AddRabbitConfig<FirstRabbitConfig>("RabbitConfiguration:FirstRabbit");
            builder.ConfigureContainer(new AutofacServiceProviderFactory(), container => {
                container.RegisterRabbitSubcriber<FirstRabbitConfig>();
            });
            var host = builder.Build();
            host.RabbitSubcriber<FirstRabbitConfig>(builder.Services).SubscribeEvent<TestEvent>();
            host.Run();
        }
    }
}