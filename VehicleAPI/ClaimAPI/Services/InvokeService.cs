using Polly;
using Polly.Extensions.Http;

namespace ClaimAPI.Services
{
    public class InvokeService :IInvokeService
    {
        private readonly HttpClient _httpClient;

        public InvokeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> DoSomething(CancellationToken cancellationToken)
        {
            string result = string.Empty;
            try
            {
                await _httpClient.GetAsync("notfounduri", cancellationToken);
                result = "Ok";
            }
            catch (Polly.CircuitBreaker.BrokenCircuitException)
            {
                result = "Service is unavailable. please try again";
            }
            return result;
        }

        public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                           .HandleTransientHttpError()
                           .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                           .WaitAndRetryAsync(2, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }
        public static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions
                           .HandleTransientHttpError()
                           .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                           .CircuitBreakerAsync(2, TimeSpan.FromSeconds(30));
        }
    }
}
