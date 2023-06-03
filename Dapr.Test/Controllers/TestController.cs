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
        public async Task<int> GetT1()
        {
            _logger.LogInformation("start");
            var request = _daprClient.CreateInvokeMethodRequest(HttpMethod.Get, "Dapr-Server", "/Test/T1");
            var data = await _daprClient.InvokeMethodAsync<List<T1>>(request);
            _logger.LogInformation($"end({data.Count})");
            return data.Count;
        }

        [HttpGet]
        [Route("T2")]
        public async Task GetT2()
        {
            _logger.LogInformation("start");
            await _daprClient.InvokeMethodGrpcAsync("Dapr-Server", "/Test/T1");
        }
    }
}