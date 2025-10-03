using CQRSExample.CQRS.Interfaces;

namespace CustomCQRS.CQRS.Interfaces;

public interface IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    Task<TResponse> Handle(TRequest request);
}
