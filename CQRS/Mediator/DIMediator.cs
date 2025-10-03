using CQRSExample.CQRS.Interfaces;
using CustomCQRS.CQRS.Interfaces;

namespace CustomCQRS.CQRS.Mediator;

public class DIMediator
{
    private readonly IServiceProvider _serviceProvider;

    public DIMediator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
    {
        // دریافت نوع هندلر مربوط به درخواست از DI
        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));

        dynamic handler = _serviceProvider.GetService(handlerType);

        if (handler == null)
            throw new Exception($"Handler for {request.GetType().Name} not registered.");

        // فراخوانی متد Handle هندلر با dynamic
        return await handler.Handle((dynamic)request);
    }
}
