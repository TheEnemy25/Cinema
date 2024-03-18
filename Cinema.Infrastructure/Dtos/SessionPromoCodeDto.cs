using Cinema.Infrastructure.Dtos.Base;

namespace Cinema.Infrastructure.Dtos
{
    public record SessionPromoCodeDto : DtoBase
    {
        public Guid SessionId { get; init; }
        public string PromoCode { get; init; }
        public decimal DiscountPercentage { get; init; }
        public int MaxUsageCount { get; init; }
    }
}
