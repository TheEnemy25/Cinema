using AutoMapper;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;
using Cinema.Infrastructure.Enums;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal sealed class TicketService : BaseService<Ticket, TicketDto>, ITicketService
    {
        private readonly IMapper _mapper;

        public TicketService(IBaseRepository<Ticket> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<IEnumerable<TicketDto>> GetTicketsByReceiptIdAsync(Guid receiptId, CancellationToken cancellationToken = default)
        {
            var tickets = await _repository
                .Query()
                .Where(t => t.ReceiptId == receiptId)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<TicketDto>>(tickets);
        }

        public async Task<IEnumerable<TicketDto>> GetTicketsBySessionIdAsync(Guid sessionId, CancellationToken cancellationToken = default)
        {
            var tickets = await _repository
                .Query()
                .Where(t => t.SessionId == sessionId)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<TicketDto>>(tickets);
        }

        public async Task<IEnumerable<TicketDto>> GetTicketsByShoppingCartIdAsync(Guid shoppingCartId, CancellationToken cancellationToken = default)
        {
            var tickets = await _repository
                .Query()
                .Where(t => t.ShoppingCartItems.Any(item => item.ShoppingCartId == shoppingCartId))
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<TicketDto>>(tickets);
        }

        public async Task<IEnumerable<TicketDto>> GetTicketsByStatusAsync(Guid receiptId, ETicketStatus status, CancellationToken cancellationToken)
        {
            var tickets = await _repository
                .Query()
                .Where(t => t.ReceiptId == receiptId && t.Status == status)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<TicketDto>>(tickets);
        }
    }
}
