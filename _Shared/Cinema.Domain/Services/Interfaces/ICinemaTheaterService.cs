using Cinema.Domain.Services.BaseService;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Domain.Services.Interfaces
{
    public interface ICinemaTheaterService : IBaseService<CinemaTheater, CinemaTheaterDto>
    {
        Task<IEnumerable<CinemaTheaterDto>> GetCinemaTheatersByCityAsync(string cityName, CancellationToken cancellationToken = default);
        Task<IEnumerable<CinemaTheaterDto>> GetCinemaTheatersWithUpcomingMoviesAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<SessionDto>> GetCinemaTheaterScheduleAsync(Guid cinemaTheaterId, CancellationToken cancellationToken = default);
    }
}
