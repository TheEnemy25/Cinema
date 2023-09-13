using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;

namespace Cinema.Domain.Services.Interfaces
{
    public interface ICinemaTheaterService : IBaseService<CinemaTheater>
    {
        Task<IEnumerable<CinemaTheater>> GetCinemaTheatersByCityAsync(string cityName);
        Task<IEnumerable<CinemaTheater>> GetCinemaTheatersWithUpcomingMoviesAsync();
        Task<IEnumerable<Session>> GetCinemaTheaterScheduleAsync(int cinemaTheaterId);
    }
}
