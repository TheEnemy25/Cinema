using Cinema.Infrastructure.Entities;
using Cinema.Domain.Services.BaseService;

namespace Cinema.Domain.Services.Interfaces
{
    public interface ISessionService : IBaseService<Session>
    {
        Task<IEnumerable<Session>> GetSessionsByMovieIdAsync(Guid movieId);
        Task<IEnumerable<Session>> GetSessionsByHallIdAsync(Guid hallId);
        Task<int> GetAvailableSeatsCountAsync(Guid sessionId);
        Task<decimal> CalculateTicketPriceAsync(Guid sessionId, string promoCode = null);
    }
}
