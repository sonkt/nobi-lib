using Autofac;
using GbLib.RabbitMQ.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace GbLib.RabbitMQ
{
    public static class Extensions
    {
        public static IServiceCollection AddRabbitConfig<TConfig>(this IServiceCollection services, string sectionName = "RabbitMq") where TConfig : RabbitConfig, new()
        {
            var resolver = services.BuildServiceProvider();
            using (var scope = resolver.CreateScope())
            {
                var config = scope.ServiceProvider.GetService<IConfiguration>();

                var options = new TConfig();
                config.Bind(sectionName, options);
                services.AddSingleton(options);

                if (options.Enabled)
                {
                    var factory = new ConnectionFactory()
                    {
                        HostName = options.Hostnames[0],
                        UserName = options.Username,
                        Password = options.Password,
                        AutomaticRecoveryEnabled = options.AutomaticRecovery,
                        Port = options.Port,
                        VirtualHost = string.IsNullOrEmpty(options.VirtualHost) ? "/" : options.VirtualHost,
                        DispatchConsumersAsync = true
                    };

                    services.AddSingleton<RabbitUtility>();
                }

                return services;
            }
        }

        public static void RegisterRabbitPublisher<TConfig>(this ContainerBuilder builder) where TConfig : RabbitConfig
        {
            builder.RegisterType<RabbitMqPublisher<TConfig>>().As<IRabbitMqPublisher<TConfig>>().SingleInstance();
        }

        public static void RegisterRabbitSubcriber<TConfig>(this ContainerBuilder builder) where TConfig : RabbitConfig
        {
            builder.RegisterType<RabbitMqSubscriber<TConfig>>().As<IRabbitMqSubscriber<TConfig>>().SingleInstance();
        }

        public static IRabbitMqSubscriber<TConfig> RabbitSubcriber<TConfig>(this IApplicationBuilder app) where TConfig : RabbitConfig => new RabbitMqSubscriber<TConfig>(app);
    }
}