using Cinema.Infrastructure.Dtos.Base;

namespace Cinema.Infrastructure.Dtos
{
    public record SessionDto : DtoBase
    {
        public Guid HallId { get; init; }
        public Guid MovieId { get; init; }
        public Guid DiscountId { get; init; }
        public DateTime Date { get; init; }
        public TimeSpan StartTime { get; init; }
    }
}
