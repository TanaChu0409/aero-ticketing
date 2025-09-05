using AeroTicketing.Common.Domain;

namespace AeroTicketing.Modules.Users.Domain.Users;

public sealed class UserRegisteredDomainEvent(string userId) : DomainEvent
{
    public string UserId { get; init; } = userId;
}
