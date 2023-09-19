using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IStudioService : IBaseService<Studio>
    {
        Task<IEnumerable<Movie>> GetMoviesByStudioIdAsync(Guid studioId);
    }
}
