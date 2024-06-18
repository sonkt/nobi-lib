using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
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
            if (string.IsNullOrEmpty(jwtOptions.SecretKey))
            {
                jwtOptions.SecretKey = "SecretKey";
            }
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
                            return Task.CompletedTask;
                        },
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception is SecurityTokenExpiredException)
                            {
                                context.HttpContext.Response.StatusCode = 403;
                            }
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

        public static IEnumerable<string>? GetClaims(this HttpContext httpContext, string claimType)
        {
            return httpContext?.User?.Claims
               .Where(x => x.Type == claimType)
               .Select(x => x.Value);
        }

        public static bool TokenIsValid(this HttpContext httpContext)
        {
            var token = GetToken(httpContext);
            JwtSecurityToken jwtSecurityToken;
            try
            {
                jwtSecurityToken = new JwtSecurityToken(token);
            }
            catch (Exception)
            {
                return false;
            }

            return jwtSecurityToken.ValidTo > DateTime.UtcNow;
        }

        public static string GetToken(this HttpContext httpContext)
        {
            var authorizationHeader = httpContext.Request.Headers["authorization"];
            return string.IsNullOrEmpty(authorizationHeader)
                ? string.Empty
                : authorizationHeader.Single().Split(' ').Last();
        }

        public static bool HasPermission(this HttpContext httpContext, int[]? listPermission, string excerpt = "-1")
        {
            var permissionFromContext = httpContext?.User?.Claims?
                .Where(x => x.Type == JwtClaimsTypes.Permissions)?
                .Select(x => x.Value)?.ToList() ?? new List<string> { };
            var permissionFromInput = listPermission?.Select(p => p)?.ToList() ?? new List<int> { };
            if (permissionFromContext.Contains(excerpt)) return true;
            if (permissionFromInput != null && permissionFromContext != null)
            {
                return permissionFromInput.Any(x => permissionFromContext.Contains(x.ToString()));
            }
            return false;
        }

        public static bool HasPermissionAll(this HttpContext httpContext, int[]? listPermission, string excerpt = "-1")
        {
            var permissionFromContext = httpContext?.User?.Claims?
                .Where(x => x.Type == JwtClaimsTypes.Permissions)?
                .Select(x => x.Value)?.ToList() ?? new List<string> { };
            var permissionFromInput = listPermission?.Select(p => p)?.ToList() ?? new List<int> { };
            // Nếu có quyền -1 tức là User Admin
            if (permissionFromContext.Contains(excerpt)) return true;
            // 2 mảng không có thằng nào
            if (permissionFromInput != null && permissionFromContext != null)
            {
                return permissionFromInput.All(x => permissionFromContext.Contains(x.ToString()));
            }
            return false;
        }

        public static bool IsAuthenticated(this HttpContext httpContext) => httpContext?.User?.Identity?.IsAuthenticated ?? false;
    }
}