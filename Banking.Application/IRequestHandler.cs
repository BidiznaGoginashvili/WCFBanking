namespace Banking.Application
{
    public interface IRequestHandler<TRequest, TResponse>
    {
        TResponse Handle(TRequest request);
    }
}
