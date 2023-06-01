using Microsoft.AspNetCore.Mvc;

namespace Dapr.Server.Controllers
{
    [Route("[controller]")]
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}