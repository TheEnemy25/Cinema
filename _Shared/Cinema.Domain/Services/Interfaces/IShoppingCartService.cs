using Cinema.Infrastructure.Entities;
using Cinema.Domain.Services.BaseService;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IShoppingCartService : IBaseService<ShoppingCart>
    {
        Task AddItemToCartWithSessionAsync(string userId, Guid productId, Guid sessionId, Guid seatId, int quantity);
        Task RemoveItemFromCartWithSessionAsync(string userId, Guid productId, Guid sessionId, Guid seatId);
        Task<IEnumerable<ShoppingCartItem>> GetItemsInCartAsync(string userId);
        Task<decimal> GetTotalCartAmountAsync(string userId);
    }
}
