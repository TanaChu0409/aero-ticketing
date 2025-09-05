using AeroTicketing.Common.Domain;

namespace AeroTicketing.Modules.Users.Domain.Users;

public sealed class UserPassportNumberUpdatedDomainEvent(string userId, string passportNumber) : DomainEvent
{
    public string UserId { get; init; } = userId;
    public string PassportNumber { get; init; } = passportNumber;
}
