using Cinema.Infrastructure.Entities.Interfaces;

namespace Cinema.Infrastructure.Entities
{
    public class ProductPromoCode : IEntity
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }

        public string PromoCode { get; set; } // Промокод для фільму
        public decimal DiscountPercentage { get; set; } // Відсоток знижки
        public int MaxUsageCount { get; set; } // Максимальна кількість використань

        //Relationships
        public Product Product{ get; set; }
        public ICollection<UserProductPromoCode> UserProductPromoCodes { get; set; }
    } 
}