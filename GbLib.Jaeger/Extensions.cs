using Jaeger;
using Jaeger.Reporters;
using Jaeger.Samplers;
using Jaeger.Senders.Thrift;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTracing;
using OpenTracing.Contrib.NetCore.Configuration;
using OpenTracing.Util;
using System.Diagnostics;

namespace GbLib.Jaeger
{
    public static class Extensions
    {
        #region Fields

        private static bool _initialized;

        private static string JaegerSectionName = "Jaeger";

        #endregion Fields

        #region Methods

        public static IServiceCollection AddJaeger(this IServiceCollection services)
        {
            if (_initialized)
            {
                return services;
            }

            _initialized = true;
            var svcProvider = services.BuildServiceProvider();
            var config = svcProvider.GetRequiredService<IConfiguration>();
            var jaegerOptions = new JaegerOptions();
            config.Bind(JaegerSectionName, jaegerOptions);
            services.AddSingleton(jaegerOptions);

            if (!jaegerOptions.Enabled)
            {
                var defaultTracer = DefaultTracer.Create();
                services.AddSingleton(defaultTracer);
                return services;
            }

            services.AddOpenTracing();

            services.AddSingleton<ITracer>(sp =>
            {
                var serviceName = sp.GetRequiredService<IWebHostEnvironment>().ApplicationName;

                var loggerFactory = sp.GetRequiredService<ILoggerFactory>();

                var reporter = new RemoteReporter
                        .Builder()
                    .WithSender(new UdpSender(jaegerOptions.UdpHost, jaegerOptions.UdpPort, jaegerOptions.MaxPacketSize))
                    .WithLoggerFactory(loggerFactory)
                    .Build();

                var sampler = new ConstSampler(true);

                var tracer = new Tracer.Builder(string.IsNullOrEmpty(jaegerOptions.ServiceName) ? serviceName : jaegerOptions.ServiceName)
                    .WithReporter(reporter)
                    .WithSampler(sampler)
                    .Build();

                GlobalTracer.Register(tracer);

                return tracer;
            });
            services.Configure<HttpHandlerDiagnosticOptions>(options =>
                options.OperationNameResolver = request => $"{request.Method.Method}: {request?.RequestUri?.AbsoluteUri}"
            );
            return services;
        }

        #endregion Methods
    }
}