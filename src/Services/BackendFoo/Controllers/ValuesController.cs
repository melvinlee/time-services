using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

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
            var serviceName = _configuration.GetValue<string>("SERVICE_NAME");
            var version = _configuration.GetValue<string>("VERSION") ?? "v1";

            return $"backend-{serviceName}:{version}";
        }
    }
}
