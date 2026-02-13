using EKart.Core.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EKart.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCoreDI(this IServiceCollection services)
    {
        return services;
    }
}
