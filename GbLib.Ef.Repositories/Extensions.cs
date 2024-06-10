using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GbLib.Ef.Repositories
{
    public static class Extensions
    {
        /// <summary>
        /// Đăng ký DBContext
        /// </summary>
        /// <typeparam name="TDbContext">DBContext Type</typeparam>
        /// <param name="services"></param>
        /// <param name="section">Section trong appsetting dạng: ConnectionStrings:ten_cau_hinh</param>
        /// <returns></returns>
        public static IServiceCollection AddDbContext<TDbContext>(this IServiceCollection services, string section) where TDbContext : DbContext
        {
            var svcProvider = services.BuildServiceProvider();
            var config = svcProvider.GetRequiredService<IConfiguration>();
            var options = new ConnectionOptions();
            config.Bind(section, options);
            services.AddSingleton(options);
            // Ưu tiên lấy trong Environment
            var connectionString = Environment.GetEnvironmentVariable("CONN_STR");
            // Nếu không có thì lấy trong options
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = options.ConnString ?? string.Empty;
                // Nếu không có thì thử lấy trong Section
                if (string.IsNullOrEmpty(connectionString))
                {
                    connectionString = config.GetConnectionString(section);
                }
            }
            services.AddDbContext<TDbContext>((sp, o) =>
            {
                o.UseSqlServer(connectionString,
                        sqlOptions =>
                        {
                            // Nếu cho phép thử lại trong chiến lược thực thi
                            if (options.EnableRetryOnFailure)
                            {
                                sqlOptions.EnableRetryOnFailure(options.MaxRetryCount, TimeSpan.FromSeconds(options.MaxRetryDelay), null);
                            }
                        })
                    .EnableSensitiveDataLogging();
            }, ServiceLifetime.Scoped);

            return services;
        }

        /// <summary>
        /// Hàm này tự động đăng ký toàn bộ các Repository mà kết thúc tồn tại cụm từ "Repository"
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddAllRepositories<T>(this IServiceCollection services) where T : class
        {
            services.Scan(scan => scan
            .FromAssemblyOf<T>()
                 .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository")))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());
            return services;
        }
    }
}
