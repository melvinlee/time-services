using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebFrontend.HttpClients
{
    public class BarService : IBarService
    {
        private readonly HttpClient _httpClient; // not exposed publicly

        public BarService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetResult()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var httpResponseMessage = await _httpClient.GetAsync("/api");
            var contents = await httpResponseMessage.Content.ReadAsStringAsync();
            stopwatch.Stop();

            var result = $"{Math.Round((decimal)stopwatch.ElapsedMilliseconds / 1000, 2)} secs {httpResponseMessage.RequestMessage.RequestUri} -> {httpResponseMessage.StatusCode} [{contents}]";
            return result;
        }
    }
}