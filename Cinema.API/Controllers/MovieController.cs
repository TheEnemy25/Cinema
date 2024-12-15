using Cinema.API.Controllers.Base;
using Cinema.Application.Commands.Movie;
using Cinema.Application.Queries.Movie;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Attributes;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    public class MovieController : CinemaControllerBase
    {
        public MovieController(IMediator mediator) : base(mediator) { }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            var movies = await _mediator.Send(request, cancellationToken);

            return Ok(movies);
        }


        [HttpGet("get-by-id")]
        [AutoValidation]
        public async Task<IActionResult> GetById([FromQuery] GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            var movie = await _mediator.Send(request, cancellationToken);

            if (movie == null)
            {
                return NotFound("Movie not found.");
            }

            return Ok(movie);
        }

        [HttpPost("create")]
        [AutoValidation]
        public async Task<IActionResult> Create([FromBody] CreateMovieCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var movie = await _mediator.Send(command, cancellationToken);
                return Ok(movie);
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex}");
                throw;
            }
        }

        [HttpPut("update")]
        [AutoValidation]
        public async Task<IActionResult> Update([FromBody] UpdateMovieCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var movie = await _mediator.Send(command, cancellationToken);
                return Ok(movie.Id);
            }

            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete")]
        [AutoValidation]
        public async Task<IActionResult> Delete(DeleteMovieCommand command, CancellationToken cancellationToken)
        {
            try
            {
                await _mediator.Send(command, cancellationToken);
                return Ok($"Movie with id {command.Id} was successfully deleted");
            }

            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}