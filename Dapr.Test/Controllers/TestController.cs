using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace Dapr.Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly DaprClient _daprClient;

        public TestController(ILogger<TestController> logger, DaprClient daprClient)
        {
            _logger = logger;
            _daprClient = daprClient;
        }

        [HttpGet]
        [Route("T1")]
        public async Task Get(int? count)
        {
            _logger.LogInformation("start");
            var data = await _daprClient.InvokeMethodAsync<int?, List<T1>>("dapr-server", "/Test/T1", count);
            _logger.LogInformation($"end({data.Count})");
        }
    }
}