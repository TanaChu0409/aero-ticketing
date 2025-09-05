using System.Reflection;
using AeroTicketing.Common.Application.Behaviors;
using AeroTicketing.Common.Infrastructure.Behaviors;
using FluentValidation;
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

            config.AddOpenBehavior(typeof(ExceptionHandlingPipelineBehavior<,>));
            config.AddOpenBehavior(typeof(RequestLoggingPipelineBehavior<,>));
            config.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
        });

        services.AddValidatorsFromAssemblies(moduleAsseblies, includeInternalTypes: true);

        return services;
    }
}
