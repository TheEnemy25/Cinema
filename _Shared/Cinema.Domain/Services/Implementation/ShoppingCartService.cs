using Cinema.Infrastructure.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal class ShoppingCartService : BaseService<ShoppingCart>, IShoppingCartService
    {
        public ShoppingCartService(IBaseRepository<ShoppingCart> repository) : base(repository)
        {
        }

        public async Task AddItemToCartWithSessionAsync(string userId, Guid productId, Guid sessionId, Guid seatId, int quantity)
        {
            var shoppingCart = await _repository
                .Query()
                .FirstOrDefaultAsync(cart => cart.UserId == userId);

            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart { UserId = userId };
                await _repository.AddAsync(shoppingCart);
            }

            var existingCartItem = shoppingCart.ShoppingCartItems
                .FirstOrDefault(item =>
                    item.ProductId == productId &&
                    item.Ticket.SessionId == sessionId &&
                    item.Ticket.SessionSeatId == seatId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += quantity;
            }
            else
            {
                var newCartItem = new ShoppingCartItem
                {
                    ProductId = productId,
                    TicketId = sessionId,
                    ShoppingCartId = shoppingCart.Id,
                    Quantity = quantity,
                    UnitPrice = 0, // Встановіть ціну за товар, якщо вам потрібно
                };

                shoppingCart.ShoppingCartItems.Add(newCartItem);
            }

            await _repository.UpdateAsync(shoppingCart);
        }

        public async Task<IEnumerable<ShoppingCartItem>> GetItemsInCartAsync(string userId)
        {
            var shoppingCart = await _repository
                .Query()
                .Include(cart => cart.ShoppingCartItems)
                    .ThenInclude(item => item.Ticket)
                        .ThenInclude(ticket => ticket.Session)
                .Where(cart => cart.UserId == userId)
                .FirstOrDefaultAsync();

            return shoppingCart?.ShoppingCartItems ?? Enumerable.Empty<ShoppingCartItem>();
        }

        public async Task<decimal> GetTotalCartAmountAsync(string userId)
        {
            var shoppingCart = await _repository
                .Query()
                .Include(cart => cart.ShoppingCartItems)
                .Where(cart => cart.UserId == userId)
                .FirstOrDefaultAsync();

            if (shoppingCart == null)
            {
                return 0;
            }

            decimal totalAmount = shoppingCart.ShoppingCartItems
                .Sum(item => item.Quantity * item.UnitPrice);

            return totalAmount;
        }

        public async Task RemoveItemFromCartWithSessionAsync(string userId, Guid productId, Guid sessionId, Guid seatId)
        {
            var shoppingCart = await _repository
                .Query()
                .FirstOrDefaultAsync(cart => cart.UserId == userId);

            if (shoppingCart == null)
            {
                return;
            }

            var existingCartItem = shoppingCart.ShoppingCartItems
                .FirstOrDefault(item =>
                    item.ProductId == productId &&
                    item.TicketId == sessionId &&
                    item.Ticket.SessionSeatId == seatId);

            if (existingCartItem != null)
            {
                shoppingCart.ShoppingCartItems.Remove(existingCartItem);
                await _repository.UpdateAsync(shoppingCart);
            }
        }
    }
}
