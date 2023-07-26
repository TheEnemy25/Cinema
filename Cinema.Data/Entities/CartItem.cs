namespace Cinema.Data.Entities
{
    public class CartItem
    {
        public Guid CartItemId { get; set; }
        public Guid UserId { get; set; }

        public int Quantity { get; set; }

        public User User { get; set; } // Зв'язок з моделлю "User"
    }
}
