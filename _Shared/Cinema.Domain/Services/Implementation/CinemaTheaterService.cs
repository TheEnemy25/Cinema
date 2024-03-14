using AutoMapper;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal sealed class CinemaTheaterService : BaseService<CinemaTheater, CinemaTheaterDto>, ICinemaTheaterService
    {
        private readonly IMapper _mapper;

        public CinemaTheaterService(IBaseRepository<CinemaTheater> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<IEnumerable<CinemaTheaterDto>> GetCinemaTheatersByCityAsync(string cityName, CancellationToken cancellationToken = default)
        {
            var cinemaThreaters = await _repository
                .Query()
                .Where(t => t.City.Name == cityName)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<CinemaTheaterDto>>(cinemaThreaters);
        }

        public async Task<IEnumerable<SessionDto>> GetCinemaTheaterScheduleAsync(Guid cinemaTheaterId, CancellationToken cancellationToken = default)
        {
            var session = await _repository
                .Query()
                .Where(t => t.Id == cinemaTheaterId)
                .SelectMany(t => t.Halls.SelectMany(h => h.Sessions))
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<SessionDto>>(session);
        }

        public async Task<IEnumerable<CinemaTheaterDto>> GetCinemaTheatersWithUpcomingMoviesAsync(CancellationToken cancellationToken = default)
        {
            var cinemaThreaters = await _repository
                .Query()
                .Where(ct => ct.Rentals.Any(r => r.RentalDate >= DateTime.Today))
                .ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<CinemaTheaterDto>>(cinemaThreaters);
        }
    }
}