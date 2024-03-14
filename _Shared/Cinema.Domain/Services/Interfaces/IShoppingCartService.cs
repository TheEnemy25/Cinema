using Cinema.Infrastructure.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Infrastructure.Dtos;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IShoppingCartService : IBaseService<ShoppingCart, ShoppingCartDto>
    {
        Task AddItemToCartWithSessionAsync(Guid userId, Guid productId, Guid sessionId, Guid seatId, int quantity, CancellationToken cancellationToken = default);
        Task RemoveItemFromCartWithSessionAsync(Guid userId, Guid productId, Guid sessionId, Guid seatId, CancellationToken cancellationToken = default);
        Task<IEnumerable<ShoppingCartDto>> GetItemsInCartAsync(Guid userId, CancellationToken cancellationToken = default);
        Task<decimal> GetTotalCartAmountAsync(Guid userId, CancellationToken cancellationToken = default);
    }
}
