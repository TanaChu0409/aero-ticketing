using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace AeroTicketing.Common.Application;

public static class ApplicationConfiguration
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        Assembly[] moduleAsseblies)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(moduleAsseblies);
        });

        return services;
    }
}
