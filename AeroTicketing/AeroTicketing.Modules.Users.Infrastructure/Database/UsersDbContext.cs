using AeroTicketing.Modules.Users.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace AeroTicketing.Modules.Users.Infrastructure.Database;
public sealed class UsersDbContext(DbContextOptions<UsersDbContext> options)
    : DbContext(options)
{
    internal DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Users);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsersDbContext).Assembly);
    }
}
