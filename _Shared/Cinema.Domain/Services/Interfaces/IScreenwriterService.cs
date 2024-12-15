using Cinema.Domain.Services.BaseService;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IScreenwriterService : IBaseService<Screenwriter, ScreenwriterDto>
    {
        Task<IEnumerable<ScreenwriterDto>> GetScreenwritersByMovieAsync(Guid movieId, CancellationToken cancellationToken = default);
        Task<IEnumerable<ScreenwriterDto>> SearchScreenwritersAsync(string query, CancellationToken cancellationToken = default);
    }
}
