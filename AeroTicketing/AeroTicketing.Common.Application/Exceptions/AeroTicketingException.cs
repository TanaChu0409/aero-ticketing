using AeroTicketing.Common.Domain;

namespace AeroTicketing.Common.Application.Exceptions;
public sealed class AeroTicketingException(
    string requestName,
    Error? error = default,
    Exception? innerException = default) 
    : Exception("Application exception", innerException)
{
    public string RequestName { get; } = requestName;
    public Error? Error { get; } = error;
}
