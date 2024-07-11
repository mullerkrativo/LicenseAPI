using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Clowdr.Core.Authorization;

public static class OpenApiExtension
{
    public static IServiceCollection AddOpenApiService(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "Relaince License API",
                    Version = "v1",
                    Description = "Reliance Endpoints",
                    Contact = new OpenApiContact
                    {
                        Name = "Relaince",
                        Email = "contact@Relainceinfosystems.com",
                        Url = new Uri("https://clowdr.io")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use Under Copyright of RelianceInfosystems",
                        Url = new Uri("https://reliancesystems.com")
                    }
                });

            options.AddSecurityDefinition("Bearer",
                new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
        });

        return services;
    }
}
