using Cinema.Domain.Services.BaseService;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IActorService : IBaseService<Actor, ActorDto>
    {
        Task<IEnumerable<ActorDto>> GetActorsByMovieAsync(Guid movieId, CancellationToken cancellationToken = default);
        Task<IEnumerable<ActorDto>> SearchActorsAsync(string query, CancellationToken cancellationToken = default);
        Task<bool> CheckIfExistsAsync(Guid id, CancellationToken cancellationToken = default);
    }
}