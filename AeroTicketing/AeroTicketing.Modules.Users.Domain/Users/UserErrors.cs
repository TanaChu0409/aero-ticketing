using AeroTicketing.Common.Domain;

namespace AeroTicketing.Modules.Users.Domain.Users;
public static class UserErrors
{
    public static Error NotFound(string userId) =>
        Error.NotFound(
            "Users.NotFound",
            $"The user with the identifier '{userId}' was not found.");

    public static Error NotFoundIDP(string identityId) =>
        Error.NotFound(
            "Users.NotFound",
            $"The user with the IDP identifier '{identityId}' was not found.");
}
