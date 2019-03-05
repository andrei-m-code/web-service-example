using ExampleService.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ExampleService
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerDocument();
            services.AddMvc()
                .AddJsonOptions(opts =>
                {
                    opts.SerializerSettings.Converters.Add(new StringEnumConverter());
                    JsonConvert.DefaultSettings = () => opts.SerializerSettings;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var isDev = env.IsDevelopment();

            if (!isDev)
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            if (isDev)
            {
                app.UseSwagger();
                app.UseSwaggerUi3();
            }

            app.UseExampleExceptionHandling();
            app.UseMvc();
        }
    }
}
