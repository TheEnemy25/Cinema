using Cinema.Domain.Services.BaseService;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IStudioService : IBaseService<Studio, StudioDto>
    {
        Task<IEnumerable<StudioDto>> GetStudiosByMovieAsync(Guid movieId, CancellationToken cancellationToken = default);
    }
}
