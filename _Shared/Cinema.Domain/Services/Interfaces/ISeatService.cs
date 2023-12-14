using Cinema.Infrastructure.Entities;
using Cinema.Infrastructure.Enums;
using Cinema.Domain.Services.BaseService;

namespace Cinema.Domain.Services.Interfaces
{
    public interface ISeatService : IBaseService<Seat>
    {
        Task<IEnumerable<Seat>> GetSeatsByHallIdAsync(Guid hallId);
        Task<IEnumerable<Seat>> GetAvailableSeatsBySessionIdAsync(Guid sessionId, Guid hallId);
        Task MarkSeatsAsOccupiedAsync(Guid sessionId, IEnumerable<Guid> seatIds);
        Task MarkSeatsAsAvailableAsync(Guid sessionId, IEnumerable<Guid> seatIds);
        Task<bool> AreSeatsAvailableAsync(Guid sessionId, IEnumerable<Guid> seatIds);
    }
}
