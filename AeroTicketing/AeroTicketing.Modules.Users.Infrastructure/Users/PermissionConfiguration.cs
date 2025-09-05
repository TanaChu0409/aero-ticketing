using AeroTicketing.Modules.Users.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AeroTicketing.Modules.Users.Infrastructure.Users;
internal sealed class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("permissions");

        builder.HasKey(p => p.Code);

        builder.Property(p => p.Code).HasMaxLength(100);

        builder.HasData(
            Permission.GetUser,
            Permission.GetUsers,
            Permission.CreateUser,
            Permission.UpdateUser);

        builder
            .HasMany<Role>()
            .WithMany()
            .UsingEntity(joinBuilder =>
            {
                joinBuilder.ToTable("role_permissions");

                joinBuilder.HasData(
                    // Admin permissions
                    CreateRolePermission(Role.Administrator, Permission.GetUser),
                    CreateRolePermission(Role.Administrator, Permission.GetUsers),
                    CreateRolePermission(Role.Administrator, Permission.CreateUser),
                    CreateRolePermission(Role.Administrator, Permission.UpdateUser),

                    // Passenger permissions
                    CreateRolePermission(Role.Passenger, Permission.GetUser),
                    CreateRolePermission(Role.Passenger, Permission.CreateUser),
                    CreateRolePermission(Role.Passenger, Permission.UpdateUser),


                    // CabinCrew permissions
                    CreateRolePermission(Role.CabinCrew, Permission.GetUser),
                    CreateRolePermission(Role.CabinCrew, Permission.CreateUser),
                    CreateRolePermission(Role.CabinCrew, Permission.UpdateUser),

                    // Pilot permissions
                    CreateRolePermission(Role.Pilot, Permission.GetUser),
                    CreateRolePermission(Role.Pilot, Permission.CreateUser),
                    CreateRolePermission(Role.Pilot, Permission.UpdateUser),

                    // CabinCrewManager permissions
                    CreateRolePermission(Role.CabinCrewManager, Permission.GetUser),
                    CreateRolePermission(Role.CabinCrewManager, Permission.GetUsers),
                    CreateRolePermission(Role.CabinCrewManager, Permission.CreateUser),
                    CreateRolePermission(Role.CabinCrewManager, Permission.UpdateUser),

                    // PilotManager permissions
                    CreateRolePermission(Role.PilotManager, Permission.GetUser),
                    CreateRolePermission(Role.PilotManager, Permission.GetUsers),
                    CreateRolePermission(Role.PilotManager, Permission.CreateUser),
                    CreateRolePermission(Role.PilotManager, Permission.UpdateUser)

                    );
            });
    }

    private static object CreateRolePermission(Role role, Permission permission) =>
        new
        {
            RolesCode = role.Name,
            PermissionsCode = permission.Code
        };
}
