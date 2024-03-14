using Cinema.Domain.Services.BaseService;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IGenreService : IBaseService<Genre, GenreDto>
    {
        Task<GenreDto> GetGenreByNameAsync(string name, CancellationToken cancellationToken = default);
        Task<IEnumerable<MovieDto>> GetGenresByMovieAsync(Guid genreId, CancellationToken cancellationToken = default);
    }
}
