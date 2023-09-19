using Cinema.Data.Entities;
using Cinema.Data.Enums;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;

namespace Cinema.Domain.Services.Implementation
{
    internal class TicketService : BaseService<Ticket>, ITicketService
    {
        public TicketService(IBaseRepository<Ticket> repository) : base(repository)
        {
        }

        public Task<IEnumerable<Ticket>> GetTicketsByReceiptIdAsync(Guid receiptId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ticket>> GetTicketsBySessionIdAsync(Guid sessionId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ticket>> GetTicketsByShoppingCartIdAsync(Guid shoppingCartId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ticket>> GetTicketsByStatusAsync(Guid receiptId, ETicketStatus status)
        {
            throw new NotImplementedException();
        }
    }
}
