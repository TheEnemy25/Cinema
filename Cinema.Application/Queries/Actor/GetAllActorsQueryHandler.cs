using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinema.Application.Queries.Actor
{
    public record GetAllActorsQuery : IRequest<IEnumerable<ActorDto>>;

    internal sealed class GetAllActorsQueryHandler : IRequestHandler<GetAllActorsQuery, IEnumerable<ActorDto>>
    {
        private readonly IActorService _actorService;
        private readonly ILogger<GetAllActorsQueryHandler> _logger;

        public GetAllActorsQueryHandler(IActorService actorService, ILogger<GetAllActorsQueryHandler> logger)
        {
            _actorService = actorService;
            _logger = logger;
        }

        public async Task<IEnumerable<ActorDto>> Handle(GetAllActorsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Retrieving all actors");

            var actors = await _actorService.GetAllAsync(cancellationToken);

            _logger.LogInformation("Retrieved all actors successfully");

            return actors;
        }
    }
}
