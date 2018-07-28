using System;
using System.Net.Http;
using Polly;
using Polly.Extensions.Http;

namespace BuildingBlock.Resilience
{
    public static class HtpClientResilience
    {
        public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(int retryCount = 3)
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2,retryAttempt)));
        }

        public static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy(int handledEventsAllowedBeforeBreaking = 3, TimeSpan? durationOfBreak = null)
        {
            var duration = durationOfBreak ?? TimeSpan.FromSeconds(30);

            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(handledEventsAllowedBeforeBreaking, duration);
        }
    }
}
