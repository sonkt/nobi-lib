using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GbLib.Analytics
{
    public static class Extensions
    {
        public static IServiceCollection AddAnalytics(this IServiceCollection services, string configSection)
        {
            var svcProvider = services.BuildServiceProvider();
            var config = svcProvider.GetRequiredService<IConfiguration>();

            var option = new AnalyticsOptions();
            config.Bind(configSection, option);
            services.AddSingleton(option);
            services.AddScoped(typeof(IAnalyticService),typeof(AnalyticsOptions));
            return services;
        }
    }
}
