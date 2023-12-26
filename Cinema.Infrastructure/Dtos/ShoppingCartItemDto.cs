namespace Cinema.Infrastructure.Dtos
{
    public record ShoppingCartItemDto
    {
        public Guid Id { get; init; }
        public Guid ShoppingCartId { get; init; }
        public Guid TicketId { get; init; }
        public Guid ProductId { get; init; }
        public int Quantity { get; init; }
        public decimal UnitPrice { get; init; }
    }
}
