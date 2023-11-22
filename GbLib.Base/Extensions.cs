using Autofac;
using GbLib.Base.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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

        public static IMvcCoreBuilder AddCustomMvc(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("DatOrigins",
                builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            using (var serviceProvider = services.BuildServiceProvider())
            {
                var configuration = serviceProvider.GetService<IConfiguration>();
                var kestrelOptions = new KestrelServerOptions();
                configuration.Bind("Kestrel", kestrelOptions);
                services.Configure<KestrelServerOptions>("Kestrel", configuration);
            }

            services.AddSingleton<ISelfInfoService, SelfInfoService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services
                .AddMvcCore(options =>
                {
                    options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
                    options.UseCentralRoutePrefix(new RouteAttribute("api/v{version:apiVersion}"));
                })
                .AddDataAnnotations()
                .AddAuthorization();
        }

        public static IApplicationBuilder UseAllForwardedHeaders(this IApplicationBuilder builder)
       => builder.UseForwardedHeaders(new ForwardedHeadersOptions
       {
           ForwardedHeaders = ForwardedHeaders.All
       });

        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        => builder.UseMiddleware<ErrorHandlerMiddleware>();
    }
}