using AutoMapper;
using Cinema.Domain.Services.BaseService;
using Cinema.Domain.Services.Interfaces;
using Cinema.Infrastructure.Dtos;
using Cinema.Infrastructure.Entities;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.Implementation
{
    internal sealed class ReceiptService : BaseService<Receipt, ReceiptDto>, IReceiptService
    {
        private readonly IMapper _mapper;

        public ReceiptService(IBaseRepository<Receipt> repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<decimal> GetAverageReceiptAmountByMonthAsync(int year, int month, CancellationToken cancellationToken)
        {
            var receipts = await _repository
                    .Query()
                    .Where(r => r.CreatedAt.Year == year && r.CreatedAt.Month == month)
                    .ToListAsync(cancellationToken);

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

        public async Task<IEnumerable<ReceiptDto>> GetReceiptByShoppingCartIdAsync(Guid shoppingCartId, CancellationToken cancellationToken)
        {
            var receipts = await _repository
                .Query()
                .Where(r => r.ShoppingCartId == shoppingCartId)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ReceiptDto>>(receipts);
        }

        public async Task<IEnumerable<ReceiptDto>> GetReceiptsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken)
        {
            var receipts = await _repository
                .Query()
                .Where(r => r.CreatedAt >= startDate && r.CreatedAt <= endDate)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ReceiptDto>>(receipts);
        }

        public async Task<IEnumerable<ReceiptDto>> GetReceiptsByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            var receipts = await _repository
                .Query()
                .Where(r => r.ShoppingCart.UserId == userId)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ReceiptDto>>(receipts);
        }

        public async Task<decimal> GetTotalAmountByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken)
        {
            var receipts = await _repository
                .Query()
                .Where(r => r.CreatedAt >= startDate && r.CreatedAt <= endDate)
                .ToListAsync(cancellationToken);

            decimal totalAmount = receipts.Sum(r => r.TotalAmount);

            return totalAmount;
        }
    }
}
