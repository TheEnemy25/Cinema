using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal class ProductService : BaseService<Product>, IProductService
    {
        public ProductService(IBaseRepository<Product> repository) : base(repository)
        {
        }

        public async Task<IEnumerable<Product>> GetAllProductsSortedByNameAsync()
        {
            var products = await _repository
               .Query()
               .OrderBy(p => p.Name)
               .ToListAsync();

            return products;
        }

        public async Task<IEnumerable<Product>> GetAllProductsSortedByPriceAsync()
        {
            var products = await _repository
                .Query()
                .OrderBy(p => p.Price)
                .ToListAsync();

            return products;
        }

        public async Task<IEnumerable<Product>> GetAllProductsSortedByPriceDescendingAsync()
        {
            var products = await _repository
                .Query()
                .OrderByDescending(p => p.Price)
                .ToListAsync();

            return products;
        }

        public async Task<IEnumerable<Product>> GetMostPopularProductsAsync()
        {
            var products = await _repository
                .Query()
                .Include(p => p.ShoppingCartItems)
                .ToListAsync();

            // Визначити кількість продажів для кожного продукту
            var productsWithSalesCount = products.Select(product => new
            {
                Product = product,
                SalesCount = product.ShoppingCartItems.Count
            });

            var sortedProducts = productsWithSalesCount.OrderByDescending(p => p.SalesCount).Select(p => p.Product);

            return sortedProducts;
        }

        public async Task<IEnumerable<Product>> GetProductsWithDiscountAsync()
        {
            var productsWithDiscount = await _repository
               .Query()
               .Where(p => p.ProductPromoCodes.Any(pc => pc.MaxUsageCount > 0))
               .ToListAsync();

            return productsWithDiscount;
        }
    }
}
