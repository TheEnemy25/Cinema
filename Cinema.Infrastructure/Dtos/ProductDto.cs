using Cinema.Infrastructure.Dtos.Base;

namespace Cinema.Infrastructure.Dtos
{
    public record ProductDto : DtoBase
    {
        public Guid DiscountId { get; init; }
        public string Name { get; init; }
        public string Image { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
    }
}
