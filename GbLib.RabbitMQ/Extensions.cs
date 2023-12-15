using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System.Reflection;

namespace GbLib.RabbitMQ
{
    public static class Extensions
    {
        public static IServiceCollection AddBusRabbitMq(this IServiceCollection services)
        {
            var resolver = services.BuildServiceProvider();
            using (var scope = resolver.CreateScope())
            {
                var config = scope.ServiceProvider.GetService<IConfiguration>();

                var options = new RabbitMqOptions();
                config.Bind("RabbitMq", options);
                services.AddSingleton(options);
                if (options.Enabled)
                {
                    var factory = new ConnectionFactory()
                    {
                        HostName = options.Hostnames[0],
                        //RequestedConnectionTimeout = TimeSpan.FromSeconds(options.RequestTimeout),
                        UserName = options.Username,
                        Password = options.Password,
                        AutomaticRecoveryEnabled = options.AutomaticRecovery,
                        Port = options.Port,
                        VirtualHost = string.IsNullOrEmpty(options.VirtualHost) ? "/" : options.VirtualHost,
                        //NetworkRecoveryInterval = TimeSpan.FromSeconds(options.RecoveryInterval)
                    };

                    services.AddSingleton<IConnectionFactory>(factory);
                    services.AddSingleton<RabbitUtility>();
                }

                return services;
            }
        }

        public static void BuildContainerRabbitMqEventBus(this ContainerBuilder builder, Assembly assembly = null)
        {
            builder.RegisterType<RabbitMqPublisher>().As<IRabbitMqPublisher>().OnActivating(e => e.Instance.Init()).SingleInstance();
            builder.RegisterType<RabbitMqSubscriber>().As<IRabbitMqSubscriber>().InstancePerLifetimeScope();
        }

        public static IRabbitMqSubscriber RabbitMqEventBusSubcriber(this IApplicationBuilder app)
           => new RabbitMqSubscriber(app);
    }
}