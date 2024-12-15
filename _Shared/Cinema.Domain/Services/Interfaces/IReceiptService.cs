using Cinema.Domain.Services.BaseService;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;

namespace Cinema.Domain.Services.Interfaces
{
    public interface IReceiptService : IBaseService<Receipt, ReceiptDto>
    {
        Task<IEnumerable<ReceiptDto>> GetReceiptByShoppingCartIdAsync(Guid shoppingCartId, CancellationToken cancellationToken = default);
        Task<IEnumerable<ReceiptDto>> GetReceiptsByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
        Task<IEnumerable<ReceiptDto>> GetReceiptsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
        Task<decimal> GetTotalAmountByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
        Task<decimal> GetAverageReceiptAmountByMonthAsync(int year, int month, CancellationToken cancellationToken = default);
    }
}
