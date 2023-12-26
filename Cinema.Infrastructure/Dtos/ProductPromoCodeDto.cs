namespace Cinema.Infrastructure.Dtos
{
    public record ProductPromoCodeDto
    {
        public Guid Id { get; init; }
        public Guid ProductId { get; init; }
        public string PromoCode { get; init; }
        public decimal DiscountPercentage { get; init; }
        public int MaxUsageCount { get; init; }
    }
}
