using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System.Reflection;

namespace GbLib.RMQ
{
    public static class ServiceCollectionExtensions
    {
        [Obsolete("Thư viện này chỉ dùng với 1 Server Rabbit. Để có thể sử dụng nhiều, vui lòng chuyển sang GbLib.RabbitMq Version 1.3.0 trở lên")]
        public static IServiceCollection AddRabbitMq(this IServiceCollection services, IConfiguration config)
        {
            var configSection = config.GetSection("RabbitMq");

            var options = new RabbitMqOptions();
            configSection.Bind(options);
            services.AddSingleton(options);
            services.AddSingleton<IConnectionFactory>(sp => new ConnectionFactory
            {
                HostName = options.Hostnames[0],
                UserName = options.Username,
                Password = options.Password,
                AutomaticRecoveryEnabled = options.AutomaticRecovery,
                Port = options.Port,
                VirtualHost = string.IsNullOrEmpty(options.VirtualHost) ? "/" : options.VirtualHost,
                DispatchConsumersAsync = true
            });

            services.AddSingleton<ModelFactory>();
            services.AddSingleton(sp => sp.GetRequiredService<ModelFactory>().CreateChannel());
            services.AddSingleton<RabbitUtility>();
            return services;
        }

        [Obsolete("Có thể sử dụng xxxByPosfix trong thư viện GbLib.Base")]
        public static void UseRabbitMq(this ContainerBuilder builder, Assembly? assembly = null)
        {
            if (assembly == null)
            {
                assembly = Assembly.GetCallingAssembly();
            }

            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(IRabbitEventHandler<>))
                .SingleInstance();
        }
    }
}