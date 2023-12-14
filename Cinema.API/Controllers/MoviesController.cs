using Cinema.Data.Context;
using Cinema.Data.Entities;
using Cinema.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        //private readonly IMovieService _movieService;


        public MoviesController(/*IMovieService movieService,*/ ApplicationDbContext context)
        {
            _context = context;
            //_movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        //{
        //    var movies = await _movieService.GetAllAsync();
        //    return Ok(movies);
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Movie>> GetMovie(Guid id)
        //{
        //    var movie = await _movieService.GetByIdAsync(id);

        //    if (movie == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(movie);
        //}

        //[HttpPost]
        //public async Task<ActionResult<Movie>> CreateMovie([FromBody] Movie movie)
        //{
        //    if (movie == null)
        //    {
        //        return BadRequest();
        //    }

        //    await _movieService.CreateAsync(movie);

        //    return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateMovie(Guid id, [FromBody] Movie movie)
        //{
        //    if (id != movie.Id)
        //    {
        //        return BadRequest();
        //    }

        //    await _movieService.UpdateAsync(movie);

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteMovie(Guid id)
        //{
        //    var existingMovie = await _movieService.GetByIdAsync(id);

        //    if (existingMovie == null)
        //    {
        //        return NotFound();
        //    }

        //    await _movieService.DeleteAsync(id);

        //    return NoContent();
        //}

        [HttpGet("~/api/ping")]
        public IActionResult Ping() => Ok("Pong");
    }
}