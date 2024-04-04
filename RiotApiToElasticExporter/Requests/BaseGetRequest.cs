using Polly;
using Polly.Retry;
using Polly.Wrap;
using System.Text.Json;

namespace RiotApiToElasticExporter.Requests
{
    internal abstract class BaseGetRequest<T>
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        private readonly AsyncPolicyWrap<HttpResponseMessage> policy;

        public abstract string Url { get; }

        protected HttpClient HttpClient { get; }

        protected BaseGetRequest(HttpClient httpClient)
        {
            HttpClient = httpClient;

            policy = Policy.WrapAsync(
                CreateRateLimitPolicy(),
                CreateDefaultPolicy()
                );
        }

        private AsyncRetryPolicy<HttpResponseMessage> CreateRateLimitPolicy()
        {
            return Policy.HandleResult<HttpResponseMessage>(r => r.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                .WaitAndRetryAsync([
                    TimeSpan.FromSeconds(2),
                    TimeSpan.FromMinutes(2)
                    ], OnRetry);
        }

        private AsyncRetryPolicy<HttpResponseMessage> CreateDefaultPolicy()
        {
            return Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .WaitAndRetryAsync([
                    TimeSpan.FromSeconds(5),
                    ], OnRetry);
        }

        private void OnRetry(DelegateResult<HttpResponseMessage> result, TimeSpan sleepTime)
        {
            Console.WriteLine($"Request failed with status {result.Result.StatusCode}. Waiting {sleepTime.TotalSeconds} seconds before retrying");
        }

        public async Task<T> ExecuteAsync()
        {
            var response = await policy.ExecuteAsync(() => HttpClient.GetAsync(Url));

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(content, _jsonSerializerOptions);
        }
    }
}
