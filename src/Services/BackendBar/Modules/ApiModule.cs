using Microsoft.Extensions.Configuration;
using Nancy;

namespace BackendBar.Modules
{

    public class ApiModule : NancyModule
    {

        public ApiModule(IConfiguration configuration) : base ("/api")
        {
            Get("/", args =>
            {
                var serviceName = configuration.GetValue<string>("SERVICE_NAME");
                var version = configuration.GetValue<string>("VERSION") ?? "v1";
                var secret = configuration.GetValue<string>("SECRET");

                return $"backend-{serviceName} (secret:{secret}):{version}";
            });
        }
    }
}
