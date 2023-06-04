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
            var request = _daprClient.CreateInvokeMethodRequest(HttpMethod.Get, "Dapr-Server", "/Test/T1");
            var data = await _daprClient.InvokeMethodAsync<List<T1>>(request);
            return data.Count;
        }

        [HttpGet]
        [Route("sayhi")]
        public async Task sayhi()
        {
            await _daprClient.InvokeMethodGrpcAsync("Dapr-Server", "sayhi");
        }
    }
}