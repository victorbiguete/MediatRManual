namespace MediatRManual.Interface
{
    public interface IMediatr
    {
        Task<TResponse> Send<TRequest, TResponse>(TRequest request);
    }
}
