namespace ClaimAPI.Services
{
    public interface IInvokeService
    {
        Task<string> DoSomething(CancellationToken cancellationToken);
    }
}
