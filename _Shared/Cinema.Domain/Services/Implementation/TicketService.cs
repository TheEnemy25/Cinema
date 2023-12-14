using Cinema.Infrastructure.Entities;
using Cinema.Infrastructure.Enums;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal class TicketService : BaseService<Ticket>, ITicketService
    {
        public TicketService(IBaseRepository<Ticket> repository) : base(repository)
        {
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByReceiptIdAsync(Guid receiptId)
        {
            var tickets = await _repository
                .Query()
                .Where(t => t.ReceiptId == receiptId)
                .ToListAsync();

            return tickets;
        }

        public async Task<IEnumerable<Ticket>> GetTicketsBySessionIdAsync(Guid sessionId)
        {
            var tickets = await _repository
                .Query()
                .Where(t => t.SessionId == sessionId)
                .ToListAsync();

            return tickets;
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByShoppingCartIdAsync(Guid shoppingCartId)
        {
            var tickets = await _repository
                .Query()
                .Where(t => t.ShoppingCartItems.Any(item => item.ShoppingCartId == shoppingCartId))
                .ToListAsync();

            return tickets;
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByStatusAsync(Guid receiptId, ETicketStatus status)
        {
            var tickets = await _repository
                .Query()
                .Where(t => t.ReceiptId == receiptId && t.Status == status)
                .ToListAsync();

            return tickets;
        }
    }
}
