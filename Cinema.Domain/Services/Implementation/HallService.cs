using Cinema.Data.Entities;
using Cinema.Data.Enums;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;

namespace Cinema.Domain.Services.Implementation
{
    internal class HallService : BaseService<Hall>, IHallService
    {
        public HallService(IBaseRepository<Hall> repository) : base(repository)
        {
        }

        public Task<IEnumerable<Hall>> GetHallsByCinemaTheaterIdAsync(Guid cinemaTheaterId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Hall>> GetHallsByStatusAsync(EHallStatus status)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Hall>> GetHallsByTypeAsync(EHallType hallType)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Hall>> GetHallsWithMoreNormalSeatsAsync(int seatCount)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Hall>> GetHallsWithMoreVIPSeatsAsync(int seatCount)
        {
            throw new NotImplementedException();
        }
    }
}
