using AutoMapper;
using Cinema.Data.Infrastructure;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal sealed class ProductService : BaseService<Product, ProductDto>, IProductService
    {
        private readonly IMapper _mapper;

        public ProductService(IBaseRepository<Product> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<IEnumerable<ProductDto>> GetAllProductsSortedByNameAsync(CancellationToken cancellationToken)
        {
            var products = await _repository
               .Query()
               .OrderBy(p => p.Name)
               .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsSortedByPriceAsync(CancellationToken cancellationToken)
        {
            var products = await _repository
                .Query()
                .OrderBy(p => p.Price)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsSortedByPriceDescendingAsync(CancellationToken cancellationToken)
        {
            var products = await _repository
                .Query()
                .OrderByDescending(p => p.Price)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<IEnumerable<ProductDto>> GetMostPopularProductsAsync(CancellationToken cancellationToken)
        {
            var products = await _repository
                .Query()
                .Include(p => p.ShoppingCartItems)
                .ToListAsync(cancellationToken);

            // Визначити кількість продажів для кожного продукту
            var productsWithSalesCount = products.Select(product => new
            {
                Product = product,
                SalesCount = product.ShoppingCartItems.Count
            });

            var sortedProducts = productsWithSalesCount.OrderByDescending(p => p.SalesCount).Select(p => p.Product);

            return _mapper.Map<IEnumerable<ProductDto>>(sortedProducts);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsWithDiscountAsync(CancellationToken cancellationToken)
        {
            var productsWithDiscount = await _repository
               .Query()
               .Where(p => p.ProductPromoCodes.Any(pc => pc.MaxUsageCount > 0))
               .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ProductDto>>(productsWithDiscount);
        }
    }
}
