using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ApiToApi_consul.Common.Configuration;
using ApiToApi_consul.Common.Extensions;

namespace ApiToApi_consul.serviceA
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
            services.AddHealthChecks();

            //services.AddControllers();

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiToApi_consul.serviceA", Version = "v1" });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // Consul goes here

            app.UseConsul("ServiceA", "api_to_api");

            var healthConfiguration = new HealthConfiguration();

            // ----------------

            var rnd = new Random();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks(healthConfiguration.HealthEndpoint);

                endpoints.MapGet("/", async context =>
                {
                    Console.WriteLine($"Requesting at {DateTime.Now}");

                    if (rnd.Next(1, 10) < 5)
                        context.Response.StatusCode = 500;
                    else
                        await context.Response.WriteAsJsonAsync(new[]
                        {
                            new {Id = 1, Text = "Hello"},
                            new {Id = 2, Text = "it's"},
                            new {Id = 3, Text = "ServiceA"}
                        });
                });
            });
        }
    }
}
