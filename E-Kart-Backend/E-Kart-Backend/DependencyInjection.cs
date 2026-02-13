using EKart.Application;
using EKart.Core;
using EKart.Core.JwtConfig;
using EKart.Core.Options;
using EKart.Infrastructure;
using EKart.Infrastructure.JwtConfig;

namespace E_Kart_Backend;

public static class DependencyInjection
{
    public static IServiceCollection AddAppDI(this IServiceCollection services, IConfiguration config)
    {
        services.AddCoreDI();
        services.AddApplicationDI();
        services.AddInfrastructureDI();

        services.AddCors(options =>
        {
            options.AddPolicy("AllowWeb", policy =>
            {
                policy.WithOrigins("http://localhost:4200").
                AllowAnyMethod().
                AllowAnyHeader().AllowCredentials();
            });
        });
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();


        services.Configure<JwtConfigOptions>(config.GetSection(JwtConfigOptions.SectionName));


        return services;
    }
}
