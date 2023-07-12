namespace Cinema.Data.Entities
{
    public class ProductPromoCode
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid DiscountId { get; set; }
        public string PromoCode { get; set; } // Промокод для продукту

        public Product Product { get; set; } // Продукт, пов'язаний з промокодом
        public Discount Discount { get; set; } // Знижка, пов'язана з промокодом
    }
}
