using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiToApi_consul.Common.Configuration
{
    public class HealthConfiguration
    {
        public bool UseHealthCheck { get; set; } = false;
        public string HealthEndpoint { get; set; } = "/health";
        public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(5);
        public TimeSpan Interval { get; set; } = TimeSpan.FromSeconds(30);
        public TimeSpan DeregisterServiceAfter { get; set; } = TimeSpan.FromMinutes(1);
    }
}
