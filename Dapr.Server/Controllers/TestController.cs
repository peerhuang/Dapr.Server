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
        public List<T1> GetT1(int? count)
        {
            var output = new List<T1>();
            for (var i = 0; i < (count ?? 10); i++)
            {
                output.Add(new T1()
                {
                    V1 = Random.Shared.Next(0, int.MaxValue).ToString(),
                    V2 = Random.Shared.Next(0, int.MaxValue).ToString(),
                    V3 = Random.Shared.Next(0, int.MaxValue).ToString(),
                    V4 = Random.Shared.Next(0, int.MaxValue).ToString(),
                    V5 = Random.Shared.Next(0, int.MaxValue).ToString(),
                    V6 = Random.Shared.Next(0, int.MaxValue).ToString(),
                });
            }
            return output;
        }
    }
}