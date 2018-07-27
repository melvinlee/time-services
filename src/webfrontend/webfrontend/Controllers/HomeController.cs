using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Configuration;

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
        public ActionResult<IEnumerable<string>> Index()
        {
            var version = _configuration.GetValue<string>("version") ?? "v1";

            return new string[] { $"frontend:{version} (host: {Environment.MachineName})"};
        }

    }
}
