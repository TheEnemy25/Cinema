using Cinema.Application.Models.Register;
using Cinema.Application.Models.SignIn;
using Cinema.Data.Entities;
using Exam.Data.Infrastructure;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Application.Controllers
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
            var userManager = HttpContext.RequestServices.GetRequiredService<UserManager<AppUser>>();
            return Ok("pong");
        }
    }       
}