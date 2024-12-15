using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Identity.Controllers
{
    [AllowAnonymous]
    [Route("~/test")]
    public class TestController : ControllerBase
    {
        public TestController()
        {

        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("API is alive!");
        }
    }
}