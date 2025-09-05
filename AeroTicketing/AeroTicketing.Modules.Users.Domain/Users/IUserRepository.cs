namespace AeroTicketing.Modules.Users.Domain.Users;
public interface IUserRepository
{
    Task<User?> GetAsync(string id, CancellationToken cancellationToken = default);
    void Insert(User user);
    void Update(User user);
}
