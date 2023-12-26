namespace Cinema.Infrastructure.Dtos
{
    public record SessionPromoCodeDto
    {
        public Guid Id { get; init; }
        public Guid SessionId { get; init; }
        public string PromoCode { get; init; }
        public decimal DiscountPercentage { get; init; }
        public int MaxUsageCount { get; init; }
    }
}
