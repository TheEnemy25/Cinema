using Cinema.API.Controllers.Base;
using Cinema.Application.Commands.Actor;
using Cinema.Application.Queries.Actor;
using Cinema.Infrastructure.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Attributes;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    public class ActorController : CinemaControllerBase
    {

        public ActorController(IMediator mediator) : base(mediator) { }


        [HttpGet("get-all")]
        [AutoValidation]
        public async Task<IActionResult> GetAll([FromQuery] GetAllActorsQuery request, CancellationToken cancellationToken)
        {
            var actors = await _mediator.Send(request, cancellationToken);

            return Ok(actors);
        }

        [HttpGet("get-by-id")]
        [AutoValidation]
        public async Task<IActionResult> GetById([FromQuery] GetActorByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var actorDto = await _mediator.Send(request, cancellationToken);

                if (actorDto == null)
                {
                    return NotFound();
                }

                return Ok(actorDto);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("create")]
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
        [AutoValidation]
        public async Task<IActionResult> Update([FromBody] UpdateActorCommand command, CancellationToken cancellationToken)
        {
            try
            {
                await _mediator.Send(command, cancellationToken);
                return Ok($"Actor with id {command.Id} was successfully updated");
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete")]
        [AutoValidation]
        public async Task<IActionResult> Delete(DeleteActorCommand command, CancellationToken cancellationToken)
        {
            try
            {
                await _mediator.Send(command, cancellationToken);
                return Ok($"Actor with id {command.Id} was successfully deleted");
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
