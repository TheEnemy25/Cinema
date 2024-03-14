using Cinema.Domain.Services.BaseService;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IDirectorService : IBaseService<Director, DirectorDto>
    {
        Task<IEnumerable<DirectorDto>> GetDirectorsByMovieAsync(Guid movieId, CancellationToken cancellationToken = default);
        Task<IEnumerable<DirectorDto>> SearchDirectorsAsync(string query, CancellationToken cancellationToken = default);
    }
}
