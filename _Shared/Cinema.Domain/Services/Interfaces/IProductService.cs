using Cinema.Domain.Services.BaseService;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IProductService : IBaseService<Product, ProductDto>
    {
        Task<IEnumerable<ProductDto>> GetAllProductsSortedByPriceAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<ProductDto>> GetAllProductsSortedByPriceDescendingAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<ProductDto>> GetAllProductsSortedByNameAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<ProductDto>> GetProductsWithDiscountAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<ProductDto>> GetMostPopularProductsAsync(CancellationToken cancellationToken = default);
    }
}
