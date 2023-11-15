using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IProductService : IBaseService<Product>
    {
        Task<IEnumerable<Product>> GetAllProductsSortedByPriceAsync();
        Task<IEnumerable<Product>> GetAllProductsSortedByPriceDescendingAsync();
        Task<IEnumerable<Product>> GetAllProductsSortedByNameAsync();
        Task<IEnumerable<Product>> GetProductsWithDiscountAsync();
        Task<IEnumerable<Product>> GetMostPopularProductsAsync();
    }
}
