using AutoMapper;
using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinema.Application.Commands.Actor
{
    public record CreateActorCommand(string FullName, string Image, string Biography, string Country, DateTime DateOfBirth) : IRequest<Guid>;

    internal sealed class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, Guid>
    {
        private readonly IActorService _actorService;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateActorCommandHandler> _logger;

        public CreateActorCommandHandler(IActorService actorService, IMapper mapper, ILogger<CreateActorCommandHandler> logger)
        {
            _actorService = actorService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateActorCommand request, CancellationToken cancellationToken)
        {
            var actorDto = _mapper.Map<ActorDto>(request);

            _logger.LogInformation($"Creation of actor begins");

            var actorId = await _actorService.CreateAsync(actorDto, cancellationToken);

            _logger.LogInformation($"Creation of actor with id {actorId} was successfull");

            return actorId;
        }
    }
}