using Cinema.Data.Entities;
using Cinema.Domain.Services.BaseService;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IReceiptService : IBaseService<Receipt>
    {
        Task<IEnumerable<Receipt>> GetReceiptByShoppingCartIdAsync(Guid shoppingCartId);
        Task<IEnumerable<Receipt>> GetReceiptsByUserIdAsync(string userId);
        Task<IEnumerable<Receipt>> GetReceiptsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<decimal> GetTotalAmountByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<decimal> GetAverageReceiptAmountByMonthAsync(int year, int month);
    }
}
