using Cinema.Infrastructure.Dtos.Base;

namespace Cinema.Infrastructure.Dtos
{
    public record ShoppingCartDto : DtoBase
    {
        public Guid ReceiptId { get; init; }
        public Guid UserId { get; init; }
    }
}
