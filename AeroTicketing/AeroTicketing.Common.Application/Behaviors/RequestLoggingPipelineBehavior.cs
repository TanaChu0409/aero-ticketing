using System.Diagnostics;
using AeroTicketing.Common.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AeroTicketing.Common.Application.Behaviors;
internal sealed class RequestLoggingPipelineBehavior<TRequest, TResponse>(
    ILogger<RequestLoggingPipelineBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
    where TResponse : Result
{
    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        string moduleName = GetModuleName(typeof(TRequest).FullName!);
        string requestName = typeof(TRequest).Name;

        Activity.Current?.SetTag("request.module", moduleName);
        Activity.Current?.SetTag("request.name", requestName);

        logger.LogInformation(
            "Processing request {RequestName}", requestName);

        TResponse result = await next(cancellationToken);

        if (result.IsSuccess)
        {
            logger.LogInformation("Completed request {RequestName}", requestName);
        }
        else
        {
            logger.LogError("Completed request {RequestName} with error", requestName);
        }

        return result;
    }
    private static string GetModuleName(string requestName) =>
        requestName.Split('.')[2];
}
