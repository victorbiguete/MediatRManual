using MediatRManual.Interface;

namespace MediatRManual.Mediatr
{
    public class Mediator : IMediatr
    {
        private readonly IServiceProvider _serviceProvider;

        public Mediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Send<TRequest, TResponse>(TRequest request)
        {
            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(typeof(TRequest), typeof(TResponse));

            var handler = _serviceProvider.GetRequiredService(handlerType);

            return await (Task<TResponse>) handler.GetType()
                .GetMethod("Handle")!
                .Invoke(handler, new object[] { request });
        }
    }
}
