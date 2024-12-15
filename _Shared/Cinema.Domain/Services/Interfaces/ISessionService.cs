using Cinema.Domain.Services.BaseService;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Domain.Services.Interfaces
{
    public interface ISessionService : IBaseService<Session, SessionDto>
    {
        Task<IEnumerable<SessionDto>> GetSessionsByMovieIdAsync(Guid movieId, CancellationToken cancellationToken = default);
        Task<IEnumerable<SessionDto>> GetSessionsByHallIdAsync(Guid hallId, CancellationToken cancellationToken = default);
        Task<int> GetAvailableSeatsCountAsync(Guid sessionId, CancellationToken cancellationToken = default);
        Task<decimal> CalculateTicketPriceAsync(Guid sessionId, string promoCode = null, CancellationToken cancellationToken = default);
    }
}
