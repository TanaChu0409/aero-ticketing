using AeroTicketing.Common.Application.Clock;
using AeroTicketing.Common.Infrastructure.Clock;
using Microsoft.Extensions.DependencyInjection;

namespace AeroTicketing.Common.Infrastructure;
public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}
