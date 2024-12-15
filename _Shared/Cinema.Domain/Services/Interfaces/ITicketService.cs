using Cinema.Domain.Services.BaseService;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;
using Cinema.Infrastructure.Enums;

namespace Cinema.Domain.Services.Interfaces
{
    public interface ITicketService : IBaseService<Ticket, TicketDto>
    {
        Task<IEnumerable<TicketDto>> GetTicketsBySessionIdAsync(Guid sessionId, CancellationToken cancellationToken = default);
        Task<IEnumerable<TicketDto>> GetTicketsByReceiptIdAsync(Guid receiptId, CancellationToken cancellationToken = default);
        Task<IEnumerable<TicketDto>> GetTicketsByStatusAsync(Guid receiptId, ETicketStatus status, CancellationToken cancellationToken = default);
        Task<IEnumerable<TicketDto>> GetTicketsByShoppingCartIdAsync(Guid shoppingCartId, CancellationToken cancellationToken = default);
    }
}
