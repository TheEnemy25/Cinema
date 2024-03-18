using Cinema.Infrastructure.Dtos.Base;

namespace Cinema.Infrastructure.Dtos
{
    public record UserProductPromoCodeDto : DtoBase
    {
        public Guid UserId { get; init; }
        public Guid ProductPromoCodeId { get; init; }
        public DateTime UsageDate { get; init; }
    }
}
