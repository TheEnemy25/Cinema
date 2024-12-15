using Cinema.Infrastructure.Dtos.Base;

namespace Cinema.Infrastructure.Dtos
{
    public record ShoppingCartItemDto : DtoBase
    {
        public Guid ShoppingCartId { get; init; }
        public Guid TicketId { get; init; }
        public Guid ProductId { get; init; }
        public int Quantity { get; init; }
        public decimal UnitPrice { get; init; }
    }
}
