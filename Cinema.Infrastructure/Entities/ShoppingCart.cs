using Cinema.Infrastructure.Entities.Interfaces;

namespace Cinema.Infrastructure.Entities
{
    public class ShoppingCart : IEntity
    {
        public Guid Id { get; set; }
        public Guid ReceiptId { get; set; }
        public Guid UserId { get; set; }


        public Receipt Receipt { get; set; }
        public AppUser User { get; set; }
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } // Зв'язок з елементами кошика
    }
}
