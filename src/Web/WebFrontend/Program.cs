using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace WebFrontend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                // Kubernetes Liveness and Readiness Probes
                // The kubelet uses readiness probes to know when a Container is ready to start accepting traffic.
                .UseHealthChecks("/readiness")
                // The kubelet uses liveness probes to know when to restart a Container.
                .UseHealthChecks("/liveness")
                .UseStartup<Startup>();
    }
}
