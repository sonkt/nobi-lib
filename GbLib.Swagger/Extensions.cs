using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace GbLib.Swagger
{
    public static class Extensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            var svcProvider = services.BuildServiceProvider();
            var config = svcProvider.GetRequiredService<IConfiguration>();

            var swaggerOptions = new SwaggerOptions();
            config.Bind("Swagger", swaggerOptions);
            services.AddSingleton(swaggerOptions);
            services.Configure<SwaggerOptions>(config.GetSection("Swagger"));

            services.AddSingleton(swaggerOptions);
            services.AddSwaggerGen(options =>
            {
                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(description.GroupName, new OpenApiInfo
                    {
                        Version = description.ApiVersion.ToString(),
                        Title = swaggerOptions.Title,
                        Description = swaggerOptions.Description,
                        TermsOfService = new Uri("https://example.com/terms"),
                        Contact = new OpenApiContact
                        {
                            Name = "Mobile",
                            Email = swaggerOptions.Contact,
                            Url = new Uri("https://twitter.com/spboyer"),
                        },
                        License = new OpenApiLicense
                        {
                            Name = "Mobile LICX",
                            Url = new Uri("https://example.com/license"),
                        }
                    });
                }

                OpenApiSecurityScheme securityDefinition = new OpenApiSecurityScheme()
                {
                    Name = "Bearer",
                    BearerFormat = "JWT",
                    Scheme = "bearer",
                    Description = "Specify the authorization accessToken.",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http
                };
                options.AddSecurityDefinition("jwt_auth", securityDefinition);

                OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme()
                {
                    Reference = new OpenApiReference()
                    {
                        Id = "jwt_auth",
                        Type = ReferenceType.SecurityScheme
                    }
                };
                OpenApiSecurityRequirement securityRequirements = new OpenApiSecurityRequirement()
                {
                    {securityScheme, new string[] { }},
                };
                options.AddSecurityRequirement(securityRequirements);

                options.SchemaFilter<SwaggerExcludeFilter>();

                options.OperationFilter<SwaggerDefaultValues>();
            });

            services.AddSwaggerGenNewtonsoftSupport();
            services.AddApiVersioning()
                .AddApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });
            return services;
        }

        public static IApplicationBuilder UseSwagger(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var options = scope.ServiceProvider.GetService<IOptions<SwaggerOptions>>();
                if (!options.Value.Enabled)
                {
                    return app;
                }

                var routePrefix = string.IsNullOrWhiteSpace(options.Value.RoutePrefix) ? "swagger" : options.Value.RoutePrefix;

                app.UseStaticFiles()
                    .UseSwagger(c => c.RouteTemplate = routePrefix + "/{documentName}/swagger.json");

                return app.UseSwaggerUI(c =>
                {
                    var provider = scope.ServiceProvider.GetRequiredService<IApiVersionDescriptionProvider>();
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        c.SwaggerEndpoint($"/{routePrefix}/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }

                    c.RoutePrefix = routePrefix;
                });
            }
        }
    }
}