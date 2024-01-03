namespace Cinema.Infrastructure.Dtos
{
    public record UserSessionPromoCodeDto
    {
        public Guid UserId { get; init; }
        public Guid SessionPromoCodeId { get; init; }
        public DateTime UsageDate { get; init; }
    }
}
