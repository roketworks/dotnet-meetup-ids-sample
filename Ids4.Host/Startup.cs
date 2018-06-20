using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ids4.Host.Config;
using Ids4.Host.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ids4.Host
{
    public class Startup : IStartup
    {
        private IConfiguration Configuration { get; }
        private IHostingEnvironment Environment { get; }

        public Startup(IConfiguration config, IHostingEnvironment env)
        {
            Configuration = config;
            Environment = env;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services
                .AddIdentityServer(config => {
                    config.Events.RaiseInformationEvents = true; 
                    config.Events.RaiseFailureEvents = true;
                    config.Events.RaiseSuccessEvents = true; 
                    config.Events.RaiseErrorEvents = true;
                    config.IssuerUri = "http://identityserver";
                })
                .AddInMemoryIdentityResources(Resources.GetIdentityResources())
                .AddInMemoryApiResources(Resources.GetApiResources())
                .AddInMemoryClients(Resources.GetClients())
                .AddProfileService<ProfileService>()
                .AddDeveloperSigningCredential();

            return services.BuildServiceProvider(validateScopes: true);
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
