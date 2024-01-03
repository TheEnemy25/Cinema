namespace Cinema.Infrastructure.Dtos
{
    public record ShoppingCartDto
    {
        public Guid Id { get; init; }
        public Guid ReceiptId { get; init; }
        public Guid UserId { get; init; }
    }
}
