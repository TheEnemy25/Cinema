using Cinema.Infrastructure.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal sealed class ReceiptService : BaseService<Receipt>, IReceiptService
    {
        public ReceiptService(IBaseRepository<Receipt> repository) : base(repository) { }

        public async Task<decimal> GetAverageReceiptAmountByMonthAsync(int year, int month)
        {
            var receipts = await _repository
                    .Query()
                    .Where(r => r.CreatedAt.Year == year && r.CreatedAt.Month == month)
                    .ToListAsync();

            if (receipts.Any())
            {
                decimal averageAmount = receipts.Average(r => r.TotalAmount);
                return averageAmount;
            }

            else
            {
                return 0;
            }
        }

        public async Task<IEnumerable<Receipt>> GetReceiptByShoppingCartIdAsync(Guid shoppingCartId)
        {
            var receipts = await _repository
                .Query()
                .Where(r => r.ShoppingCartId == shoppingCartId)
                .ToListAsync();

            return receipts;
        }

        public async Task<IEnumerable<Receipt>> GetReceiptsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var receipts = await _repository
                .Query()
                .Where(r => r.CreatedAt >= startDate && r.CreatedAt <= endDate)
                .ToListAsync();

            return receipts;
        }

        public async Task<IEnumerable<Receipt>> GetReceiptsByUserIdAsync(Guid userId)
        {
            var receipts = await _repository
                .Query()
                .Where(r => r.ShoppingCart.UserId == userId)
                .ToListAsync();

            return receipts;
        }

        public async Task<decimal> GetTotalAmountByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var receipts = await _repository
                .Query()
                .Where(r => r.CreatedAt >= startDate && r.CreatedAt <= endDate)
                .ToListAsync();

            decimal totalAmount = receipts.Sum(r => r.TotalAmount);

            return totalAmount;
        }
    }
}
