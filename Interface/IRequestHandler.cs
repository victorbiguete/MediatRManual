namespace MediatRManual.Interface
{
    public interface IRequestHandler<TRequest,TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }
}
