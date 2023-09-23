using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IActorService : IBaseService<Actor>
    {
        Task<IEnumerable<Actor>> GetActorsByMovieAsync(Guid movieId);
        Task<IEnumerable<Actor>> SearchActorsAsync(string query);
    }
}