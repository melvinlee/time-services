using Microsoft.Extensions.Configuration;
using Nancy;
using Nancy.TinyIoc;

namespace BackendBar
{
    public class BootStrapper : DefaultNancyBootstrapper
    {
        private readonly IConfiguration _configuration;

        public BootStrapper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register<IConfiguration>(_configuration);
        }
    }
}