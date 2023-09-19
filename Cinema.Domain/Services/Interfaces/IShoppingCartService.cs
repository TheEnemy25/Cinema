using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IShoppingCartService : IBaseService<ShoppingCart>
    {
        Task AddItemToCartWithSessionAsync(Guid userId, Guid productId, Guid sessionId, int quantity);
        Task RemoveItemFromCartWithSessionAsync(Guid userId, Guid productId, Guid sessionId);
        Task<IEnumerable<ShoppingCartItem>> GetItemsInCartAsync(Guid userId);
        Task<decimal> GetTotalCartAmountAsync(Guid userId);
    }
}
