

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Hosting
{
    public static class HealthCheckExtension
    {
        /// <summary>
        /// Use Kubernetes Readiness ("/readiness") and Liveness ("/liveness") Probes. 
        /// </summary>
        /// <param name="webHostBuilder"></param>
        /// <returns></returns>
        public static IWebHostBuilder UseReadinessAndLivenessHealthChecks(this IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.UseHealthChecks("/readiness").UseHealthChecks("/liveness");
            return webHostBuilder;
        }
    }
}
