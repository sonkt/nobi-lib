using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System.Net;

namespace Nobi.Redis
{
    public static class Extensions
    {
        public static IServiceCollection AddRedisCache(this IServiceCollection services)
        {
            var svcProvider = services.BuildServiceProvider();
            var config = svcProvider.GetRequiredService<IConfiguration>();
            var redisOptions = new RedisOptions();
            config.Bind("Redis", redisOptions);

            if (redisOptions.Enabled)
            {
                services.AddSingleton(redisOptions);
                services.AddStackExchangeRedisCache(options =>
                {
                    options.ConfigurationOptions = new ConfigurationOptions
                    {
                        EndPoints =
                        {
                            new DnsEndPoint(redisOptions?.Host??"redis", redisOptions?.Port ?? 6379)
                        },
                        ResolveDns = redisOptions?.ResolveDns ?? true,
                        Password = redisOptions?.Password ?? "",
                        ServiceName = redisOptions?.ServiceName,
                        ConnectRetry = redisOptions?.ConnectRetry ?? 10,
                        AllowAdmin = redisOptions?.AllowAdmin ?? true,
                        DefaultDatabase = redisOptions?.DefaultDatabase ?? -1,
                    };
                });
                services.AddSingleton<IRedisConnectionWrapper, RedisConnectionWrapper>();
                services.AddSingleton<IRedisCache, RedisCacheService>();
            }
            return services;
        }

    }
}