using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;

        public ActorController(IActorService actorService)
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
        public async Task<IActionResult> SearchActorsAsync([FromQuery] string query)
        {
            var actors = await _actorService.SearchActorsAsync(query);

            if (actors == null || !actors.Any())
            {
                return NotFound("No actors found for the specified search query.");
            }

            return Ok(actors);
        }

        [HttpGet]
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
            var actor = new Actor();
            actor.Id = Guid.NewGuid();
            actor.FullName = actorDto.FullName;
            actor.Image = actorDto.Image;
            actor.Biography = actorDto.Biography;
            actor.DateOfBirth = actorDto.DateOfBirth;

            await _actorService.CreateAsync(actor);
            return Ok(actor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] ActorDto actorDto)
        {
            var actor = await _actorService.GetByIdAsync(id);

            if (actor == null)
            {
                return NotFound($"Actor with ID {id} not found.");
            }

            actor.FullName = actorDto.FullName;
            actor.Image = actorDto.Image;
            actor.Biography = actorDto.Biography;
            actor.DateOfBirth = actorDto.DateOfBirth;

            await _actorService.UpdateAsync(actor);
            return Ok(actor);
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
