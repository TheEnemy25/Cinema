using Cinema.Infrastructure.Dtos.Base;

namespace Cinema.Infrastructure.Dtos
{
    public record DiscountDto : DtoBase
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public int Amount { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
    }
}
