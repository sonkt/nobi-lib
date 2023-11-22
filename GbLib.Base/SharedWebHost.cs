using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GbLib.Base
{
    public static class SharedWebHost
    {
        public static T AddAppSettings<T>(this IServiceCollection services, string configName = "AppSettingOptions") where T : class
        {
            var svcProvider = services.BuildServiceProvider();
            var config = svcProvider.GetRequiredService<IConfiguration>();
            var appconfig = (T)Activator.CreateInstance(typeof(T));
            config.Bind(configName, appconfig);
            services.AddSingleton(appconfig);
            services.Configure<T>(config.GetSection(configName));
            return appconfig;
        }
    }
}