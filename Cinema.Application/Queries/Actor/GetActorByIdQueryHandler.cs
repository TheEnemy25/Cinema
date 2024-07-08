using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Cinema.Application.Queries.Actor
{
    public record GetActorByIdQuery(Guid Id) : IRequest<ActorDto>;

    internal sealed class GetActorByIdQueryHandler : IRequestHandler<GetActorByIdQuery, ActorDto>
    {
        private readonly IActorService _actorService;
        private readonly ILogger<GetActorByIdQueryHandler> _logger;

        public GetActorByIdQueryHandler(IActorService actorService, ILogger<GetActorByIdQueryHandler> logger)
        {
            _actorService = actorService;
            _logger = logger;
        }

        public async Task<ActorDto> Handle(GetActorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _actorService.GetByIdAsync(request.Id, cancellationToken);
        }
    }
}
