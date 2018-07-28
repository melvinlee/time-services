using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using WebFrontend.HttpClients;

namespace webfrontend.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: /<controller>/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Index([FromServices] IFooService fooService, [FromServices]  IBarService barService)
        {
            var version = _configuration.GetValue<string>("version") ?? "v1";

            return new[] { $"frontend:{version} (host: {Environment.MachineName})", await fooService.GetResult(), await barService.GetResult() };
        }
    }
}
