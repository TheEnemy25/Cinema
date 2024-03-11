using AutoMapper;
using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using MediatR;

namespace Cinema.Application.Queries.Actor
{
    public record SearchActorsQuery(string Query) : IRequest<IEnumerable<ActorDto>>;

    // TODO: Rename
    internal sealed class SearchActorsQueryHandler : IRequestHandler<SearchActorsQuery, IEnumerable<ActorDto>>
    {
        private readonly IActorService _actorService;
        // TODO: Move mapping to services
        private readonly IMapper _mapper;

        public SearchActorsQueryHandler(IActorService actorService, IMapper mapper)
        {
            _actorService = actorService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ActorDto>> Handle(SearchActorsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _actorService.SearchActorsAsync(request.Query, cancellationToken);

            return _mapper.Map<IEnumerable<ActorDto>>(entities);
        }
    }
}