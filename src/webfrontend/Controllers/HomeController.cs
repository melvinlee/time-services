using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;

namespace webfrontend.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        // GET: /<controller>/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Index()
        {
            var version = _configuration.GetValue<string>("version") ?? "v1";

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // foo backend
            var client = _httpClientFactory.CreateClient("FooServices");
            var fooResult =  await client.GetAsync("/api");
            stopwatch.Stop();

            var fooReturnValue = $"{Math.Round((decimal)stopwatch.ElapsedMilliseconds / 1000, 2)} secs {_configuration.GetValue<string>("BACKEND_URL_FOO")} -> {fooResult.StatusCode}";

            //bar backend
            stopwatch.Restart();
            var barResult = await client.GetAsync("/api");
            stopwatch.Stop();

            var barReturnValue = $"{Math.Round((decimal)stopwatch.ElapsedMilliseconds / 1000, 2)} secs {_configuration.GetValue<string>("BACKEND_URL_BAR")} -> {fooResult.StatusCode}";

            return new string[] { $"frontend:{version} (host: {Environment.MachineName})", fooReturnValue, barReturnValue };
        }
    }
}
