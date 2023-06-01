using Microsoft.AspNetCore.Mvc;

namespace Dapr.Grpc
{
    public class HealthController : ControllerBase
    {
        [HttpGet]
        [Route("/health")]
        public ActionResult Health()
        {
            return this.Ok();
        }
    }
}