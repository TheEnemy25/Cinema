using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using MediatR;

namespace Cinema.Application.Queries.Actor
{
    public record GetActorByIdQuery(Guid Id) : IRequest<ActorDto>;

    internal sealed class GetActorByIdQueryHandler : IRequestHandler<GetActorByIdQuery, ActorDto>
    {
        private readonly IActorService _actorService;


        public GetActorByIdQueryHandler(IActorService actorService)
        {
            _actorService = actorService;
        }

        public async Task<ActorDto> Handle(GetActorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _actorService.GetByIdAsync(request.Id, cancellationToken);
        }
    }
}
