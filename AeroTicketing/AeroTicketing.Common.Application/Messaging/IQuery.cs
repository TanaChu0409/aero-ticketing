using AeroTicketing.Common.Domain;
using MediatR;

namespace AeroTicketing.Common.Application.Messaging;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
