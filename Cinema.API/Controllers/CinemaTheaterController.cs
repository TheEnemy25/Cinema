using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaTheaterController : ControllerBase
    {
        [HttpGet("~/api/cinema")]
        public IActionResult Cinema() => Ok("CinemaTheaterController");
    }
}