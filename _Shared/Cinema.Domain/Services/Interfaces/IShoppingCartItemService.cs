using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IShoppingCartItemService : IBaseService<ShoppingCartItem>
    {
        Task<IEnumerable<ShoppingCartItem>> GetShoppingCartItemsByUserIdAsync(string userId);
        Task AddItemToShoppingCartAsync(string userId, Guid productId, Guid sessionId, Guid seatId, int quantity);
        Task UpdateCartItemQuantityAsync(string userId, Guid productId, Guid sessionId, Guid seatId, int quantity);
        Task RemoveItemFromShoppingCartAsync(string userId, Guid productId, Guid sessionId, Guid seatId);
    }
}
