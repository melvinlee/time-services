using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace BuildingBlock.Http
{
    public class ForwardCorrelationIdHeaderHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOptions<CorrelationIdOptions> _options;
        private string _correlationToken;

        public ForwardCorrelationIdHeaderHandler(IHttpContextAccessor httpContextAccessor, IOptions<CorrelationIdOptions> options)
        {
            _httpContextAccessor = httpContextAccessor;
            _options = options;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            _correlationToken = _httpContextAccessor.HttpContext.Request?.Headers[_options.Value.CorrelationIdHeader];        
            request.Headers.Add(_options.Value.CorrelationIdHeader, _correlationToken);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
