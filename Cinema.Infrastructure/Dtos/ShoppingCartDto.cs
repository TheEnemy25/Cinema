namespace Cinema.Infrastructure.Dtos
{
    public record ShoppingCartDto
    {
        public Guid Id { get; init; }
        public Guid ReceiptId { get; init; }
        public string UserId { get; init; }
    }
}
