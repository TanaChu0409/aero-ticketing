using AeroTicketing.Common.Application.Messaging;

namespace AeroTicketing.Modules.Users.Application.Users.RegisterUser;
public sealed record RegisterUserCommand(
    string Email,
    string Password,
    string FisrtName,
    string LastName) : ICommand<string>;
