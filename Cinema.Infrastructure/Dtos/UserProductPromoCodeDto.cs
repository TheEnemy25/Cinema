namespace Cinema.Infrastructure.Dtos
{
    public record UserProductPromoCodeDto
    {
        public string UserId { get; init; }
        public Guid ProductPromoCodeId { get; init; }
        public DateTime UsageDate { get; init; }
    }
}
