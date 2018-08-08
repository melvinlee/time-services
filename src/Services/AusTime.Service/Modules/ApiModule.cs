using Microsoft.Extensions.Configuration;
using Nancy;
using System;

namespace BackendBar.Modules
{

    public class ApiModule : NancyModule
    {

        public ApiModule(IConfiguration configuration) : base ("/api")
        {
            Get("/", args =>
            {
                var version = configuration.GetValue<string>("VERSION") ?? "v1";
                var secret = configuration.GetValue<string>("SECRET");
                var time = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("AUS Eastern Standard Time"));

                return $"australia-time: {time} (secret:{secret}) ver:{version}";
            });
        }
    }
}
