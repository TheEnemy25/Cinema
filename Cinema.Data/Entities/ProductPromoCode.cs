namespace Cinema.Data.Entities
{
    public class ProductPromoCode
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }

        public string PromoCode { get; set; } // Промокод для фільму
        public decimal DiscountPercentage { get; set; } // Відсоток знижки
        public int MaxUsageCount { get; set; } // Максимальна кількість використань

        //Relationships
        public Product Product { get; set; } // Фільм, пов'язаний з промокодом
        public ICollection<PromoCodeUsage> PromoCodeUsages { get; set; } // Зв'язок з використаннями промокоду
    }
}
