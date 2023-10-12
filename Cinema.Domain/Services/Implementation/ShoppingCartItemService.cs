using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal class ShoppingCartItemService : BaseService<ShoppingCartItem>, IShoppingCartItemService
    {

        public ShoppingCartItemService(IBaseRepository<ShoppingCartItem> repository) : base(repository)
        {
        }

        public async Task AddItemToShoppingCartAsync(string userId, Guid productId, Guid sessionId, Guid seatId, int quantity)
        {
            var existingCartItem = await _repository
         .Query()
         .FirstOrDefaultAsync(item => item.ShoppingCart.UserId == userId && item.ProductId == productId && item.Ticket.SessionId == sessionId && item.Ticket.SessionSeatId == seatId);

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

        public async Task<IEnumerable<ShoppingCartItem>> GetShoppingCartItemsByUserIdAsync(string userId)
        {
            var shoppingCartItems = await _repository
                .Query()
                .Include(item => item.Ticket)
                    .ThenInclude(ticket => ticket.Session)
                .Include(item => item.Product)
                .Where(item => item.ShoppingCart.UserId == userId)
                .ToListAsync();

            return shoppingCartItems;
        }

        public async Task RemoveItemFromShoppingCartAsync(string userId, Guid productId, Guid sessionId, Guid seatId)
        {
            var existingCartItem = await _repository
                .Query()
                .FirstOrDefaultAsync(item => item.ShoppingCart.UserId == userId && item.ProductId == productId && item.Ticket.SessionId == sessionId && item.Ticket.SessionSeatId == seatId);

            if (existingCartItem != null)
            {
                await _repository.DeleteAsync(existingCartItem);
            }
        }

        public async Task UpdateCartItemQuantityAsync(string userId, Guid productId, Guid sessionId, Guid seatId, int quantity)
        {
            var existingCartItem = await _repository
                .Query()
                .FirstOrDefaultAsync(item => item.ShoppingCart.UserId == userId && item.ProductId == productId && item.Ticket.SessionId == sessionId && item.Ticket.SessionSeatId == seatId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity = quantity;
                await _repository.UpdateAsync(existingCartItem);
            }
        }
    }
}
