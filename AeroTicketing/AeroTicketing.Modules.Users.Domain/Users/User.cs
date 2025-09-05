using AeroTicketing.Common.Domain;

namespace AeroTicketing.Modules.Users.Domain.Users;

public sealed class User : Entity
{
    private readonly List<Role> _roles = [];
    public string Id { get; private set; }
    public string Email { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string PassportNumber { get; private set; }
    public string IdentityId { get; private set; }
    public IReadOnlyCollection<Role> Roles => _roles.AsReadOnly();

    public static User Create(
        string email,
        string firstName,
        string lastName,
        string passportNumber,
        string identityId,
        Role role)
    {
        var user = new User
        {
            Id = $"u_{Ulid.NewUlid()}",
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            PassportNumber = passportNumber,
            IdentityId = identityId
        };

        user._roles.Add(role);

        user.Raise(new UserRegisteredDomainEvent(user.Id));

        return user;
    }

    public void UpdateName(string firstName, string lastName)
    {
        if (FirstName == firstName && LastName == lastName)
        {
            return;
        }

        FirstName = firstName;
        LastName = lastName;
    }

    public void UpdatePassportNumber(string passportNumber)
    {
        if (PassportNumber == passportNumber)
        {
            return;
        }

        PassportNumber = passportNumber;
        Raise(new UserPassportNumberUpdatedDomainEvent(Id, PassportNumber));
    }
}
