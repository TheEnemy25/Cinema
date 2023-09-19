using Cinema.Data.Entities;
using Cinema.Data.Enums;
using Cinema.Domain.Services.BaseService;

namespace Cinema.Domain.Services.Interfaces
{
    public interface ITicketService : IBaseService<Ticket>
    {
        Task<IEnumerable<Ticket>> GetTicketsBySessionIdAsync(Guid sessionId);
        Task<IEnumerable<Ticket>> GetTicketsByReceiptIdAsync(Guid receiptId);
        Task<IEnumerable<Ticket>> GetTicketsByStatusAsync(Guid receiptId, ETicketStatus status);
        Task<IEnumerable<Ticket>> GetTicketsByShoppingCartIdAsync(Guid shoppingCartId);
    }
}
