

// ReSharper disable once CheckNamespace

using System;

namespace Microsoft.AspNetCore.Hosting
{
    public static class HealthCheckExtension
    {
        /// <summary>
        /// Use Kubernetes Readiness ("/readiness") and Liveness ("/liveness") Probes. 
        /// </summary>
        /// <param name="webHostBuilder"></param>
        /// <returns></returns>
        public static IWebHostBuilder UseReadinessAndLivenessHealthChecksDefault(this IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.UseHealthChecks("/readiness").UseHealthChecks("/liveness");
            return webHostBuilder;
        }

        /// <summary>
        /// Use Kubernetes Readiness and Liveness Probes. 
        /// </summary>
        /// <param name="webHostBuilder"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IWebHostBuilder UseReadinessAndLivenessHealthChecks(this IWebHostBuilder webHostBuilder, Action<HealthChecksConfiguration> configuration)
        {
            var healthChecksConfiguration = new HealthChecksConfiguration();
            configuration?.Invoke(healthChecksConfiguration);

            webHostBuilder.UseHealthChecks(healthChecksConfiguration.ReadinessPath).UseHealthChecks(healthChecksConfiguration.LivenessPath);
            return webHostBuilder;
        }
    }
}
