namespace Microsoft.AspNetCore.Hosting
{
    public class HealthChecksConfiguration
    {
        public string ReadinessPath { get; set; }
        public string LivenessPath { get; set; }
    }
}