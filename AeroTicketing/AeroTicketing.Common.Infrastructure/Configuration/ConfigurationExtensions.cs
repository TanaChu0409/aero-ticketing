using Microsoft.Extensions.Configuration;

namespace AeroTicketing.Common.Infrastructure.Configuration;
public static class ConfigurationExtensions
{
    public static string GetConnectionStringOrThrow(this IConfiguration configuration, string name) =>
        configuration.GetConnectionString(name) ??
            throw new InvalidOperationException($"The connection string {name} was not found");
}
