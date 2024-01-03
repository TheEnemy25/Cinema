namespace Cinema.Infrastructure.Dtos
{
    public record UserProductPromoCodeDto
    {
        public Guid UserId { get; init; }
        public Guid ProductPromoCodeId { get; init; }
        public DateTime UsageDate { get; init; }
    }
}
