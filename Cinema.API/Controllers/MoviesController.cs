﻿using Cinema.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //public IActionResult Index()
        //{
        //    var user = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "sub");
        //    return Ok(user);
        //}

    }
}
