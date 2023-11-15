using Cinema.Data.Entities.Interfaces;

namespace Cinema.Data.Entities
{
    public class ShoppingCart : IEntity
    {
        public Guid Id { get; set; }
        public Guid ReceiptId { get; set; }
        public string UserId { get; set; }


        public Receipt Receipt { get; set; }
        public AppUser User { get; set; }
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } // Зв'язок з елементами кошика
    }
}
