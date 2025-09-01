namespace AeroTicketing.Api.Extensions;

internal static class SwaggerExtensions
{
    internal static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "AeroTicketing API",
                Version = "v1",
                Description = "An API for managing airline ticketing operations.",
            });

            options.CustomSchemaIds(t => t.FullName?.Replace("+", ".", StringComparison.Ordinal));
        });

        return services;
    }
}
