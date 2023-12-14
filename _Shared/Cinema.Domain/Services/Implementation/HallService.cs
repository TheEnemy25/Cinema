using Cinema.Infrastructure.Entities;
using Cinema.Infrastructure.Enums;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal class HallService : BaseService<Hall>, IHallService
    {
        public HallService(IBaseRepository<Hall> repository) : base(repository)
        {
        }

        public async Task<IEnumerable<Hall>> GetHallsByCinemaTheaterIdAsync(Guid cinemaTheaterId)
        {
            return await _repository
                .Query()
                .Where(hall => hall.CinemaTheaterId == cinemaTheaterId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Hall>> GetHallsByStatusAsync(EHallStatus status)
        {
            return await _repository
                 .Query()
                 .Where(hall => hall.Status == status)
                 .ToListAsync();
        }

        public async Task<IEnumerable<Hall>> GetHallsByTypeAsync(EHallType hallType)
        {
            return await _repository
               .Query()
               .Where(hall => hall.HallType == hallType)
               .ToListAsync();
        }

        public async Task<IEnumerable<Hall>> GetHallsWithMoreNormalSeatsAsync(int seatCount)
        {
            return await _repository
                .Query()
                .Where(hall => hall.NormalSeatsCount > seatCount)
                .ToListAsync();
        }

        public async Task<IEnumerable<Hall>> GetHallsWithMoreVIPSeatsAsync(int seatCount)
        {
            return await _repository
                .Query()
                .Where(hall => hall.VIPSeatsCount > seatCount)
                .ToListAsync();
        }
    }
}
