using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ApiToApi_consul.Common.Consul;
using Microsoft.Extensions.Configuration;
using Consul;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Hosting.Server.Features;
using System.Reflection;

namespace ApiToApi_consul.Common.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        private static readonly ConsulHelper _consulHelper = new ConsulHelper();

        public static IApplicationBuilder UseConsul(this IApplicationBuilder app, string name, string tag)
        {
            app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>().ApplicationStarted.Register(() =>
            {
                _consulHelper.Register(app, name, tag).Wait();
            });

            return app;
        }
    }
}
