using AutoMapper;
using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinema.Application.Commands.Actor
{
    public record UpdateActorCommand(Guid Id, string FullName, string Image, string Biography, string Country, DateTime DateOfBirth) : IRequest<ActorDto>;

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

        public async Task<ActorDto> Handle(UpdateActorCommand request, CancellationToken cancellationToken)
        {
            var actor = _mapper.Map<ActorDto>(request);

            _logger.LogInformation($"Update of actor with id {request.Id} begins");

            await _actorService.UpdateAsync(actor, cancellationToken);

            _logger.LogInformation($"Actor with id {request.Id} was successfully updated");

            return actor;
        }
    }
}