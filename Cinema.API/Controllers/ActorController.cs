using Cinema.API.Controllers.Base;
using Cinema.Application.Commands.Actor;
using Cinema.Application.Queries.Actor;
using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    // TODO: Fix endpoint namings
    public class ActorController : CinemaControllerBase
    {
        //TODO: Remove service injection, replace with CQRS handlers
        private readonly IActorService _actorService;

        public ActorController(IActorService actorService, IMediator mediator) : base(mediator)
        {
            _actorService = actorService;
        }

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

        [HttpPost("{id}")]
        public async Task<IActionResult> CreateAsync([FromBody] ActorDto actorDto)
        {
            // TODO: use AutoMapper in business layer instead
            var actor = new Actor();
            actor.Id = Guid.NewGuid();
            actor.FullName = actorDto.FullName;
            actor.Image = actorDto.Image;
            actor.Biography = actorDto.Biography;
            actor.DateOfBirth = actorDto.DateOfBirth;

            //await _actorService.CreateAsync(actor);
            return Ok(actor);
        }


        // TODO: Додати валідацію, написати хендлер команди на апдейт, 
        [HttpPut("put")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateActorCommand command, CancellationToken cancellationToken)
        {
            //TODO: Move existance checks and similiar validations to business layer
            if (!await _actorService.CheckIfExistsAsync(command.Id, cancellationToken))
            {
                return NotFound($"Actor with ID {command.Id} not found.");
            }

            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var actor = await _actorService.GetByIdAsync(id);

            if (actor == null)
            {
                return NotFound($"Actor with ID {id} not found.");
            }

            await _actorService.DeleteAsync(id);
            return Ok($"Actor with ID {id} has been deleted.");
        }
    }
}
