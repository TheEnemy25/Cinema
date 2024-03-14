using Cinema.Domain.Services.BaseService;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Domain.Services.Interfaces
{
    public interface ISeatService : IBaseService<Seat, SeatDto>
    {
        Task<IEnumerable<SeatDto>> GetSeatsByHallIdAsync(Guid hallId, CancellationToken cancellationToken = default);
        Task<IEnumerable<SeatDto>> GetAvailableSeatsBySessionIdAsync(Guid sessionId, Guid hallId, CancellationToken cancellationToken = default);
        Task MarkSeatsAsOccupiedAsync(Guid sessionId, IEnumerable<Guid> seatIds, CancellationToken cancellationToken = default);
        Task MarkSeatsAsAvailableAsync(Guid sessionId, IEnumerable<Guid> seatIds, CancellationToken cancellationToken = default);
        Task<bool> AreSeatsAvailableAsync(Guid sessionId, IEnumerable<Guid> seatIds, CancellationToken cancellationToken = default);
    }
}
