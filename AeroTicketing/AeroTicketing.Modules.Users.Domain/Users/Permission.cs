namespace AeroTicketing.Modules.Users.Domain.Users;

public sealed class Permission(string code)
{
    public static readonly Permission GetUser = new("users:read");
    public static readonly Permission CreateUser = new("users:create");
    public static readonly Permission UpdateUser = new("users:update");
    public static readonly Permission GetUsers = new("users:read:all");

    public string Code { get; } = code;
}
