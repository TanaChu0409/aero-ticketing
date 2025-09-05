namespace AeroTicketing.Modules.Users.Domain.Users;

public sealed class Role
{
    public static readonly Role Administrator = new("Administrator");
    public static readonly Role Passenger = new("Passenger");
    public static readonly Role CabinCrew = new("CabinCrew");
    public static readonly Role Pilot = new("Pilot");
    public static readonly Role CabinCrewManager = new("CabinCrewManager");
    public static readonly Role PilotManager = new("PilotManager");

    private Role()
    {
    }

    private Role(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }
}
