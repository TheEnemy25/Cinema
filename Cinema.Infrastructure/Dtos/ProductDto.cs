namespace Cinema.Infrastructure.Dtos
{
    public record ProductDto
    {
        public Guid Id { get; init; }
        public Guid DiscountId { get; init; }
        public string Name { get; init; }
        public string Image { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
    }
}
