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

        public void Get()
        {
        }
    }
}