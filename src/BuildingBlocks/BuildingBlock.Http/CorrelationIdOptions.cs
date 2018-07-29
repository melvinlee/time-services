namespace BuildingBlock.Http
{
    public class CorrelationIdOptions
    {
        private const string DefaultHeader = "X-Correlation-ID";

        /// <summary>
        /// The header field name where the correlation ID will be stored
        /// </summary>
        public string CorrelationIdHeader { get; set; } = DefaultHeader;

        /// <summary>
        /// Controls whether the correlation ID is returned in the response headers
        /// </summary>
        public bool CorrelationIdIncludeInResponse { get; set; } = false;
    }
}
