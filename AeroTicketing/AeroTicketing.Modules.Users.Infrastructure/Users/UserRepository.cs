using AeroTicketing.Modules.Users.Domain.Users;
using AeroTicketing.Modules.Users.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace AeroTicketing.Modules.Users.Infrastructure.Users;
internal sealed class UserRepository(UsersDbContext dbContext) : IUserRepository
{
    public async Task<User?> GetAsync(string id, CancellationToken cancellationToken = default)
    {
        return await dbContext
            .Users
            .SingleOrDefaultAsync(
                u => u.Id == id,
                cancellationToken);
    }

    public void Insert(User user)
    {
        foreach (Role role in user.Roles)
        {
            dbContext.Attach(role);
        }

        dbContext.Users.Add(user);
    }

    public void Update(User user)
    {
        dbContext.Users.Update(user);
    }
}
