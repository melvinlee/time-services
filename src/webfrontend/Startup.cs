using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.HealthChecks;
using System;
using System.Threading.Tasks;
using BuildingBlock.Http;
using WebFrontend.HttpClients;
using static BuildingBlock.Resilience.HtpClientResilience;

namespace WebFrontend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddHealthChecks(checks =>
            {
                checks.AddValueTaskCheck("HTTP Endpoint", () => new
                    ValueTask<IHealthCheckResult>(HealthCheckResult.Healthy("Ok")));
            });

            services.AddHttpContextAccessor();
            services.AddTransient<ForwardCorrelationIdHeaderHandler>();

            services.Configure<CorrelationIdOptions>(Configuration);

            services.AddHttpClient<IFooService, FooService>(client => {
                client.BaseAddress = new Uri(Configuration.GetValue<string>("BACKEND_URL_FOO"));
                //client.DefaultRequestHeaders.Add("Accept", "application/json");
            })
                .AddPolicyHandler(GetCircuitBreakerPolicy())
                .AddHttpMessageHandler<ForwardCorrelationIdHeaderHandler>();

            services.AddHttpClient<IBarService, BarService>(client => {
                client.BaseAddress = new Uri(Configuration.GetValue<string>("BACKEND_URL_BAR"));
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            })
                .AddPolicyHandler(GetRetryPolicy())
                .AddHttpMessageHandler<ForwardCorrelationIdHeaderHandler>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
