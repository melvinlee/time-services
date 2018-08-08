using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace BackendFoo.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ValuesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // GET api/values/5
        [HttpGet()]
        public ActionResult<string> Get()
        {
            var version = _configuration.GetValue<string>("VERSION") ?? "v1";
            var time = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Asia/Singapore"));

            return $"singapore-time: {time} ver:{version}";
        }
    }
}
