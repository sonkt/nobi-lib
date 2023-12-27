using Autofac;
using GbLib.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System.Reflection;

namespace GbLib.RMQ
{
    public static class ServiceCollectionExtensions
    {
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
        public static void UseRabbitMq(this ContainerBuilder builder, Assembly? assembly = null)
        {           
            if (assembly == null)
            {
                assembly = Assembly.GetCallingAssembly();
            }

            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(IRabbitEventHandler<>))
                .InstancePerLifetimeScope();
        }
    }
}
