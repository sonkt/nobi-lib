using Autofac;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GbLib.Base
{
    public static class Extensions
    {
        public static IServiceCollection AddDomainEventBus(this IServiceCollection services)
        {
            services.Add(ServiceDescriptor.Singleton<IDomainEventDispatcher, DomainEventDispatcher>());
            return services;
        }

        public static void BuildContainerEventBus(this ContainerBuilder builder, Assembly assembly = null)
        {
            builder.RegisterAssemblyTypes(Assembly.GetCallingAssembly())
                .AsImplementedInterfaces();
            if (assembly == null)
            {
                assembly = Assembly.GetCallingAssembly();
            }

            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(IEventHandler<>))
                .InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .InstancePerLifetimeScope();
        }
    }
}
