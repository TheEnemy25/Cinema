namespace Cinema.Infrastructure.Dtos
{
    public record ReceiptDto
    {
        public Guid Id { get; init; }
        public Guid ShoppingCartId { get; init; }
        public decimal TotalAmount { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}
