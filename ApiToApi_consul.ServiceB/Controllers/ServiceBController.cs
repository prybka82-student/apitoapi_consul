using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiToApi_consul.ServiceB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceBController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceBController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("ServiceA");

            var result = await client.GetAsync("/");

            return Ok(result.Content);
        }
    }
}
