using Microsoft.Extensions.DependencyInjection;

namespace GbLib.Ef.Service
{
    public static class Extensions
    {
        /// <summary>
        /// Hàm này tự động đăng ký toàn bộ các Service mà kết thúc tồn tại cụm từ "Service"
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddAllServices<T>(this IServiceCollection services) where T : class
        {
            services.Scan(scan => scan
            .FromAssemblyOf<T>()
                 .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());
            return services;
        }
    }
}