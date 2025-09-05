using AeroTicketing.Modules.Users.Application.Abstractions.Data;
using AeroTicketing.Modules.Users.Domain.Users;
using AeroTicketing.Modules.Users.Infrastructure.Database;
using AeroTicketing.Modules.Users.Infrastructure.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AeroTicketing.Modules.Users.Infrastructure;

public static class UserModule
{
    public static IServiceCollection AddUsersModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);

        return services;
    }

    private static void AddInfrastructure(
        this IServiceCollection service,
        IConfiguration configuration)
    {
        service.AddDbContext<UsersDbContext>((sp, options) =>
            options
                .UseNpgsql(
                    configuration.GetConnectionString("Database"),
                    npgsqlOptions =>
                        npgsqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Users))
                .UseSnakeCaseNamingConvention());

        service.AddScoped<IUserRepository, UserRepository>();

        service.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<UsersDbContext>());
    }
}
