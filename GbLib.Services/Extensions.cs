using GbLib.Entities.Context;
using MicroOrm.Dapper.Repositories;
using MicroOrm.Dapper.Repositories.Config;
using MicroOrm.Dapper.Repositories.SqlGenerator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GbLib.Services
{
    public static class Extensions
    {
        public static IServiceCollection AddDapperOrm<TDbContext>(this IServiceCollection services) where TDbContext : DbContext
        {
            var svcProvider = services.BuildServiceProvider();
            var config = svcProvider.GetRequiredService<IConfiguration>();
            var options = new DbOptions();
            config.Bind("SqlServer", options);
            services.AddSingleton(options);

            MicroOrmConfig.SqlProvider = SqlProvider.MSSQL;

            var connectionString = Environment.GetEnvironmentVariable("CONN_STR");
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = options.ConnString;
            }
            services.AddScoped(typeof(ISqlGenerator<>), typeof(SqlGenerator<>));
            services.AddScoped<IDbConnectionFactory, DbConnectionFactory>(factory => new DbConnectionFactory(connectionString, SqlProvider.MSSQL));
            services.AddScoped(typeof(IDapperRepository<>), typeof(DapperRepository<>));
            services.AddDbContext<TDbContext>((sp, o) =>
            {
                var connectionString = Environment.GetEnvironmentVariable("CONN_STR");
                if (string.IsNullOrEmpty(connectionString))
                {
                    connectionString = options.ConnString;
                }
                o.UseSqlServer(connectionString,
                        sqlOptions =>
                        {
                            sqlOptions.EnableRetryOnFailure(
                                15,
                                TimeSpan.FromSeconds(30),
                                null);
                        })
                    .EnableSensitiveDataLogging();
            }, ServiceLifetime.Scoped);

            return services;
        }
    }
}