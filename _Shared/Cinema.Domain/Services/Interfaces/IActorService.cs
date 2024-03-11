using Cinema.Infrastructure.Entities;
using Cinema.Domain.Services.BaseService;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IActorService : IBaseService<Actor>
    {
        Task<IEnumerable<Actor>> GetActorsByMovieAsync(Guid movieId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Actor>> SearchActorsAsync(string query, CancellationToken cancellationToken = default);
        Task<bool> CheckIfExistsAsync(Guid id, CancellationToken cancellationToken = default);
    }
}