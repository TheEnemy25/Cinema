﻿using Cinema.Application.Models.Register;
using Cinema.Application.Models.SignIn;
using Cinema.Infrastructure.Entities;
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
            return Ok("API is alive!");
        }
    }       
}