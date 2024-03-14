using Cinema.Domain.Services.BaseService;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IShoppingCartItemService : IBaseService<ShoppingCartItem, ShoppingCartItemDto>
    {
        Task<IEnumerable<ShoppingCartItemDto>> GetShoppingCartItemsByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
        Task AddItemToShoppingCartAsync(Guid userId, Guid productId, Guid sessionId, Guid seatId, int quantity, CancellationToken cancellationToken = default);
        Task UpdateCartItemQuantityAsync(Guid userId, Guid productId, Guid sessionId, Guid seatId, int quantity, CancellationToken cancellationToken = default);
        Task RemoveItemFromShoppingCartAsync(Guid userId, Guid productId, Guid sessionId, Guid seatId, CancellationToken cancellationToken = default);
    }
}
