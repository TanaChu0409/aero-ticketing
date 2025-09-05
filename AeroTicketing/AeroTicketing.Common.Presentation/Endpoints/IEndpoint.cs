using Microsoft.AspNetCore.Routing;

namespace AeroTicketing.Common.Presentation.Endpoints;
public interface IEndpoint
{
    void MapEndpoints(IEndpointRouteBuilder app);
}
