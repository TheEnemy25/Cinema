using Cinema.API.Controllers.Base;
using Cinema.Application.Commands.Actor;
using Cinema.Application.Queries.Actor;
using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Attributes;
using System.Threading;

namespace Cinema.API.Controllers
{
    // TODO: Fix endpoint namings
    [Route("api/[controller]")]
    public class ActorController : CinemaControllerBase
    {
        //TODO: Remove service injection, replace with CQRS handlers
        private readonly IActorService _actorService;

        public ActorController(IMediator mediator) : base(mediator) { }

        [HttpGet("movieId")]
        public async Task<IActionResult> GetActorsByMovie(Guid movieId)
        {
            var actors = await _actorService.GetActorsByMovieAsync(movieId);

            if (actors == null || !actors.Any())
            {
                return NotFound("No actors found for the specified movie.");
            }
            return Ok(actors);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchActorsAsync([FromQuery] SearchActorsQuery request, CancellationToken cancellationToken)
        {
            var actors = await _mediator.Send(request, cancellationToken);

            if (actors == null || !actors.Any())
            {
                return NotFound("No actors found for the specified search query.");
            }

            return Ok(actors);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var actors = await _actorService.GetAllAsync();

            if (actors == null || !actors.Any())
            {
                return NotFound("No actors found.");
            }
            return Ok(actors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid Id)
        {
            var actor = await _actorService.GetByIdAsync(Id);

            if (actor == null)
            {
                return NotFound($"Actor with ID {Id} not found.");
            }
            return Ok(actor);
        }

        [HttpPost("create")]
        [AutoValidation]
        public async Task<IActionResult> Create([FromBody] CreateActorCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(command, cancellationToken);
                return Ok(result);
            }

            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("put")]
        public async Task<IActionResult> Update(Guid id,[FromBody] UpdateActorCommand command, CancellationToken cancellationToken)
        {
            if (id != command.Id)
            {
                return BadRequest("Id in URL does not match Id in command body");
            }

            try
            {
                await _mediator.Send(command, cancellationToken);
                return Ok($"Actor with id {id} was successfully updated");
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var command = new DeleteActorCommand(id);
                await _mediator.Send(command, cancellationToken);
                return Ok($"Actor with id {id} was successfully deleted");
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
