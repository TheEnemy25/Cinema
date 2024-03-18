using Cinema.Infrastructure.Dtos.Base;

namespace Cinema.Infrastructure.Dtos
{
    public record ReceiptDto : DtoBase
    {
        public Guid ShoppingCartId { get; init; }
        public decimal TotalAmount { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}
