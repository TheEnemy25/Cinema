using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using MediatR;

namespace Cinema.Application.Queries.Actor
{
    public record SearchActorsQuery(string Query) : IRequest<IEnumerable<ActorDto>>;

    internal sealed class SearchActorsQueryHandler : IRequestHandler<SearchActorsQuery, IEnumerable<ActorDto>>
    {
        private readonly IActorService _actorService;

        public SearchActorsQueryHandler(IActorService actorService)
        {
            _actorService = actorService;
        }

        public async Task<IEnumerable<ActorDto>> Handle(SearchActorsQuery request, CancellationToken cancellationToken)
        {
            var actors = await _actorService.SearchActorsAsync(request.Query, cancellationToken);

            return actors;
        }
    }
}