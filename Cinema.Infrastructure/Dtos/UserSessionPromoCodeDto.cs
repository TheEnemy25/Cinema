using Cinema.Infrastructure.Dtos.Base;

namespace Cinema.Infrastructure.Dtos
{
    public record UserSessionPromoCodeDto : DtoBase
    {
        public Guid UserId { get; init; }
        public Guid SessionPromoCodeId { get; init; }
        public DateTime UsageDate { get; init; }
    }
}
