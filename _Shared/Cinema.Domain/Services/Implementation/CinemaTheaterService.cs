using Cinema.Infrastructure.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal class CinemaTheaterService : BaseService<CinemaTheater>, ICinemaTheaterService
    {
        public CinemaTheaterService(IBaseRepository<CinemaTheater> repository) : base(repository)
        {
        }

        public async Task<IEnumerable<CinemaTheater>> GetCinemaTheatersByCityAsync(string cityName)
        {
            return await _repository
              .Query()
              .Where(theater => theater.City.Name == cityName)
              .ToListAsync();
        }

        public async Task<IEnumerable<Session>> GetCinemaTheaterScheduleAsync(Guid cinemaTheaterId)
        {
            return await _repository
                .Query()
                .Where(theater => theater.Id == cinemaTheaterId)
                .SelectMany(theater => theater.Halls.SelectMany(hall => hall.Sessions))
                .ToListAsync();
        }

        public async Task<IEnumerable<CinemaTheater>> GetCinemaTheatersWithUpcomingMoviesAsync()
        {
            var today = DateTime.Today;

            return await _repository
                .Query()
                .Where(theater => theater.Rentals.Any(rental => rental.RentalDate >= today))
                .ToListAsync();
        }
    }
}
