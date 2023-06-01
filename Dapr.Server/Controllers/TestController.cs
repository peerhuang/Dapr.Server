using Microsoft.AspNetCore.Mvc;

namespace Dapr.Server.Controllers
{
    [Route("[controller]")]
    public class TestController : Controller
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("T1")]
        public void Get()
        {
        }
    }
}