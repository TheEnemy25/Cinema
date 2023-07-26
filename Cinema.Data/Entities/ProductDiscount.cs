namespace Cinema.Data.Entities
{
    public class ProductDiscount
    {
        public Guid ProductId { get; set; } // Зовнішній ключ для фільму
        public Guid DiscountId { get; set; } // Зовнішній ключ для знижки

        public Product Product { get; set; }
        public Discount Discount { get; set; }
    }
}