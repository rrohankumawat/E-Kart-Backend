using EKart.Application;
using EKart.Core;
using EKart.Infrastructure;

namespace E_Kart_Backend;

public static class DependencyInjection
{
    public static IServiceCollection AddAppDI(this IServiceCollection services)
    {
        services.AddCoreDI();
        services.AddApplicationDI();
        services.AddInfrastructureDI();
        return services;
    }
}
