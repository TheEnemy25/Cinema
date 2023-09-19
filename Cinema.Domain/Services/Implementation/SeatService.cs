using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;

namespace Cinema.Domain.Services.Implementation
{
    internal class SeatService : BaseService<Seat>, ISeatService
    {
        public SeatService(IBaseRepository<Seat> repository) : base(repository)
        {
        }

        public Task<bool> AreSeatsAvailableAsync(Guid sessionId, IEnumerable<Guid> seatIds)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Seat>> GetAvailableSeatsBySessionIdAsync(Guid sessionId, Guid hallId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Seat>> GetSeatsByHallIdAsync(Guid hallId)
        {
            throw new NotImplementedException();
        }

        public Task MarkSeatsAsAvailableAsync(Guid sessionId, IEnumerable<Guid> seatIds)
        {
            throw new NotImplementedException();
        }

        public Task MarkSeatsAsOccupiedAsync(Guid sessionId, IEnumerable<Guid> seatIds)
        {
            throw new NotImplementedException();
        }
    }
}
