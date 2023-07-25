using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GbLib.Jwt
{
    public static class Extensions
    {
        public static IServiceCollection AddJwt(this IServiceCollection services)
        {
            var svcProvider = services.BuildServiceProvider();
            var config = svcProvider.GetRequiredService<IConfiguration>();

            var jwtOptions = new JwtOptions();
            config.Bind("Jwt", jwtOptions);
            services.AddSingleton(jwtOptions);
            if (!jwtOptions.Enabled)
            {
                return services;
            }
            services.AddTransient<IJwtService, JwtService>();
            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(cfg =>
                {
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.ValidAudience,
                        ValidateAudience = jwtOptions.ValidateAudience,
                        ValidateLifetime = jwtOptions.ValidateLifetime,
                        ClockSkew = TimeSpan.Zero
                    };

                    cfg.SaveToken = true;

                    cfg.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            // Lấy về token trong request.
                            // Nếu có Token thì cứ chạy bình thường
                            // Nếu không có thì kiểm tra xem có phải chạy local hoặc từ Internal
                            // Nếu chạy từ internal hoặc local thì dùng key vĩnh viễn.
                            var requestToken = context.HttpContext.Request.Headers["authorization"];
                            if (string.IsNullOrEmpty(requestToken))
                            {
                                // Đoạn này dành cho Localhost
                                if (context.HttpContext.Request.Host.Host == "localhost" || context.HttpContext.Request.Host.Host == "kong" || !context.HttpContext.Request.Headers.ContainsKey("x-via-kong"))
                                {
                                    context.Token = jwtOptions.InternalTokenKey;
                                    return Task.CompletedTask;
                                }
                            }
                            // Đoạn này dành cho SignalR
                            var accessToken = context.Request.Query["access_token"];
                            var path = context.HttpContext.Request.Path;
                            if (!string.IsNullOrEmpty(accessToken) &&
                                path.StartsWithSegments("/vehicleOnlineHub"))
                            {
                                context.Token = accessToken;
                            }
                            return Task.CompletedTask;
                        },
                        OnAuthenticationFailed = context =>
                        {
                            var te = context.Exception;
                            return Task.CompletedTask;
                        },
                        OnForbidden = context =>
                        {
                            var te = context.Properties;
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddAuthorization();
            return services;
        }

        public static long ToTimestamp(this DateTime dateTime)
        {
            var centuryBegin = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var expectedDate = dateTime.Subtract(new TimeSpan(centuryBegin.Ticks));

            return expectedDate.Ticks / 10000;
        }

        public static IApplicationBuilder UseJwtTokenValidator(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var options = scope.ServiceProvider.GetService<JwtOptions>();
                if (!options.Enabled)
                {
                    return app;
                }
                app.UseMiddleware<JwtTokenValidatorMiddleware>();
            }
            return app;
        }

    }
}