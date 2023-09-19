using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;

namespace Cinema.Domain.Services.Implementation
{
    internal class ShoppingCartService : BaseService<ShoppingCart>, IShoppingCartService
    {
        public ShoppingCartService(IBaseRepository<ShoppingCart> repository) : base(repository)
        {
        }

        public Task AddItemToCartWithSessionAsync(Guid userId, Guid productId, Guid sessionId, int quantity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShoppingCartItem>> GetItemsInCartAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetTotalCartAmountAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveItemFromCartWithSessionAsync(Guid userId, Guid productId, Guid sessionId)
        {
            throw new NotImplementedException();
        }
    }
}
