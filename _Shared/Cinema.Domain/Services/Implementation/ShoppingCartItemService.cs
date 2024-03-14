using AutoMapper;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal sealed class ShoppingCartItemService : BaseService<ShoppingCartItem, ShoppingCartItemDto>, IShoppingCartItemService
    {
        private readonly IMapper _mapper;

        public ShoppingCartItemService(IBaseRepository<ShoppingCartItem> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task AddItemToShoppingCartAsync(Guid userId, Guid productId, Guid sessionId, Guid seatId, int quantity, CancellationToken cancellationToken = default)
        {
            var existingCartItem = await _repository
                .Query()
                .FirstOrDefaultAsync(item =>
                    item.ShoppingCart.UserId == userId
                    && item.ProductId == productId
                    && item.Ticket.SessionId == sessionId
                    && item.Ticket.SessionSeatId == seatId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += quantity;
            }

            else
            {
                var newCartItem = new ShoppingCartItem
                {
                    ShoppingCart = new ShoppingCart { UserId = userId },
                    ProductId = productId,
                    Ticket = new Ticket { SessionId = sessionId, SessionSeatId = seatId },
                    Quantity = quantity
                };

                await _repository.AddAsync(newCartItem);
            }
        }

        public async Task<IEnumerable<ShoppingCartItemDto>> GetShoppingCartItemsByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            var shoppingCartItems = await _repository
                .Query()
                .Include(item => item.Ticket)
                    .ThenInclude(ticket => ticket.Session)
                .Include(item => item.Product)
                .Where(item => item.ShoppingCart.UserId == userId)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ShoppingCartItemDto>>(shoppingCartItems);
        }

        public async Task RemoveItemFromShoppingCartAsync(Guid userId, Guid productId, Guid sessionId, Guid seatId, CancellationToken cancellationToken = default)
        {
            var existingCartItem = await _repository
                .Query()
                .FirstOrDefaultAsync(item => item.ShoppingCart.UserId == userId && item.ProductId == productId && item.Ticket.SessionId == sessionId && item.Ticket.SessionSeatId == seatId);

            if (existingCartItem != null)
            {
                await _repository.DeleteAsync(existingCartItem, cancellationToken);
            }
        }

        public async Task UpdateCartItemQuantityAsync(Guid userId, Guid productId, Guid sessionId, Guid seatId, int quantity, CancellationToken cancellationToken = default)
        {
            var existingCartItem = await _repository
                .Query()
                .FirstOrDefaultAsync(item => item.ShoppingCart.UserId == userId && item.ProductId == productId && item.Ticket.SessionId == sessionId && item.Ticket.SessionSeatId == seatId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity = quantity;
                await _repository.UpdateAsync(existingCartItem, cancellationToken);
            }
        }
    }
}
