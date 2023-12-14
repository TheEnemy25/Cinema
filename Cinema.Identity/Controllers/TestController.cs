using Cinema.Identity.Models.Register;
using Cinema.Identity.Models.SignIn;
using Cinema.Infrastructure.Entities;
using Exam.Data.Infrastructure;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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