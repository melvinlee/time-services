using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace BackendFoo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseReadinessAndLivenessHealthChecks(x =>
                {
                    x.LivenessPath = "/liveness";
                    x.ReadinessPath = "/readiness";
                })
                .UseStartup<Startup>();
    }
}
