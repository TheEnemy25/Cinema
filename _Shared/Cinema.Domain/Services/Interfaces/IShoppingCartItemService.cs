using Cinema.Infrastructure.Entities;
using Cinema.Domain.Services.BaseService;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IShoppingCartItemService : IBaseService<ShoppingCartItem>
    {
        Task<IEnumerable<ShoppingCartItem>> GetShoppingCartItemsByUserIdAsync(Guid userId);
        Task AddItemToShoppingCartAsync(Guid userId, Guid productId, Guid sessionId, Guid seatId, int quantity);
        Task UpdateCartItemQuantityAsync(Guid userId, Guid productId, Guid sessionId, Guid seatId, int quantity);
        Task RemoveItemFromShoppingCartAsync(Guid userId, Guid productId, Guid sessionId, Guid seatId);
    }
}
