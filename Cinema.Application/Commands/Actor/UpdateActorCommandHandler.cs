using AutoMapper;
using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinema.Application.Commands.Actor
{
    public record UpdateActorCommand(Guid Id, string FullName, string Image, string Biography, DateTime DateOfBirth) : IRequest<ActorDto>;

    // TODO: Refactor
    internal sealed class UpdateActorCommandHandler : IRequestHandler<UpdateActorCommand, ActorDto>
    {
        private readonly IActorService _actorService;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateActorCommandHandler> _logger;

        public UpdateActorCommandHandler(IActorService actorService, IMapper mapper, ILogger<UpdateActorCommandHandler> logger)
        {
            _actorService = actorService;
            _mapper = mapper;
            _logger = logger;
        }

        async Task<ActorDto> IRequestHandler<UpdateActorCommand, ActorDto>.Handle(UpdateActorCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Update of actor with id {request.Id} begins");

            // TODO: Remove
            var actor = new Infrastructure.Entities.Actor
            {
                Id = request.Id,
                FullName = request.FullName,
                Image = request.Image,
                Biography = request.Biography,
                DateOfBirth = request.DateOfBirth,
            };

            //await _actorService.UpdateAsync(/*actor,*/ /*cancellationToken*/);

            _logger.LogInformation($"Actor with id {request.Id} was successfully updated");

            return _mapper.Map<ActorDto>(actor);
        }
    }
}