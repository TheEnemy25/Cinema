using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;

namespace Cinema.Domain.Services.Implementation
{
    internal class CinemaTheaterService : BaseService<CinemaTheater>, ICinemaTheaterService
    {
        public CinemaTheaterService(IBaseRepository<CinemaTheater> repository) : base(repository)
        {
        }

        public Task<IEnumerable<CinemaTheater>> GetCinemaTheatersByCityAsync(string cityName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Session>> GetCinemaTheaterScheduleAsync(int cinemaTheaterId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CinemaTheater>> GetCinemaTheatersWithUpcomingMoviesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
