using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;

namespace Cinema.Domain.Services.Implementation
{
    internal class ProductService : BaseService<Product>, IProductService
    {
        public ProductService(IBaseRepository<Product> repository) : base(repository)
        {
        }

        public Task<IEnumerable<Product>> GetAllProductsSortedByNameAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllProductsSortedByPriceAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllProductsSortedByPriceDescendingAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetMostPopularProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsWithDiscountAsync()
        {
            throw new NotImplementedException();
        }
    }
}
