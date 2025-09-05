using AeroTicketing.Common.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AeroTicketing.Common.Infrastructure.Behaviors;
internal sealed class ExceptionHandlingPipelineBehavior<TRequest, TResponse>(
    ILogger<ExceptionHandlingPipelineBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
{
    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        try
        {
            return await next(cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(
                ex,
                "Unhandled exception for request {RequestName}",
                typeof(TRequest).Name);
            throw new AeroTicketingException(
                typeof(TRequest).Name,
                innerException: ex);
        }
    }
}
