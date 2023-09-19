using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Exam.Data.Infrastructure;

namespace Cinema.Domain.Services.Implementation
{
    internal class ReceiptService : BaseService<Receipt>, IReceiptService
    {
        public ReceiptService(IBaseRepository<Receipt> repository) : base(repository)
        {
        }

        public Task<decimal> GetAverageReceiptAmountByMonthAsync(int year, int month)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Receipt>> GetReceiptByShoppingCartIdAsync(Guid shoppingCartId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Receipt>> GetReceiptsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Receipt>> GetReceiptsByUserIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetTotalAmountByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
}
