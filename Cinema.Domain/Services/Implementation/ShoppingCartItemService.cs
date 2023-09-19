using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;

namespace Cinema.Domain.Services.Implementation
{
    internal class ShoppingCartItemService : BaseService<ShoppingCartItem>, IShoppingCartItemService
    {
        public ShoppingCartItemService(IBaseRepository<ShoppingCartItem> repository) : base(repository)
        {
        }

        public Task AddItemToShoppingCartAsync(Guid userId, Guid productId, Guid sessionId, int quantity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShoppingCartItem>> GetShoppingCartItemsByUserIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveItemFromShoppingCartAsync(Guid userId, Guid productId, Guid sessionId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCartItemQuantityAsync(Guid userId, Guid productId, Guid sessionId, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
