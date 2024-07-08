using AutoMapper;
using Cinema.Data.Infrastructure;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal sealed class ShoppingCartService : BaseService<ShoppingCart, ShoppingCartDto>, IShoppingCartService
    {
        private readonly IMapper _mapper;

        public ShoppingCartService(IBaseRepository<ShoppingCart> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task AddItemToCartWithSessionAsync(Guid userId, Guid productId, Guid sessionId, Guid seatId, int quantity, CancellationToken cancellationToken = default)
        {
            var shoppingCart = await _repository
                .Query()
                .FirstOrDefaultAsync(cart => cart.UserId == userId, cancellationToken);

            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart { UserId = userId };
                await _repository.AddAsync(shoppingCart, cancellationToken);
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
                    UnitPrice = 0, // Встановити ціну за товар
                };

                shoppingCart.ShoppingCartItems.Add(newCartItem);
            }

            await _repository.UpdateAsync(shoppingCart);
        }

        public async Task<IEnumerable<ShoppingCartDto>> GetItemsInCartAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            var shoppingCart = await _repository
                .Query()
                .Include(cart => cart.ShoppingCartItems)
                    .ThenInclude(item => item.Ticket)
                        .ThenInclude(ticket => ticket.Session)
                .Where(cart => cart.UserId == userId)
                .FirstOrDefaultAsync(cancellationToken);

            if (shoppingCart == null)
                return Enumerable.Empty<ShoppingCartDto>();

            var shoppingCartDto = _mapper.Map<ShoppingCartDto>(shoppingCart);

            return null; // return shoppingCartDto.ShoppingCartItems;

            //return shoppingCart?.ShoppingCartItems ?? Enumerable.Empty<ShoppingCartItem>();
        }

        public async Task<decimal> GetTotalCartAmountAsync(Guid userId, CancellationToken cancellationToken = default)
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

        public async Task RemoveItemFromCartWithSessionAsync(Guid userId, Guid productId, Guid sessionId, Guid seatId, CancellationToken cancellationToken = default)
        {
            var shoppingCart = await _repository
                .Query()
                .FirstOrDefaultAsync(cart => cart.UserId == userId, cancellationToken);

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
                await _repository.UpdateAsync(shoppingCart, cancellationToken);
            }
        }
    }
}
