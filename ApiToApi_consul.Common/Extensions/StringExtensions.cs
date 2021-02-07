using ApiToApi_consul.Common.Consul;
using Consul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiToApi_consul.Common.Extensions
{
    public static class StringExtensions
    {
        private static readonly ConsulHelper _consulHelper = new();

        public static string? GetServiceUrl(this string serviceName)
        {
            var service = _consulHelper.GetServiceConfiguration(serviceName);

            return service is not null ? GenerateUrl(service) : null;

            string GenerateUrl(AgentService agentService) => $"{agentService.Address}:{agentService.Port}";
        }
    }
}
