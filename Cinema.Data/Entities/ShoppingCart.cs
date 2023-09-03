using Cinema.Data.Entities.Interfaces;

namespace Cinema.Data.Entities
{
    public class ShoppingCart : IEntity
    {
        public Guid Id { get; set; }
        public Guid ReceiptId { get; set; }

        public Receipt Receipt { get; set; }
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } // Зв'язок з елементами кошика
    }
}

//       public Guid UserId { get; set; }
