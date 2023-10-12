using Cinema.Data.Entities.Interfaces;

namespace Cinema.Data.Entities
{
    public class SessionPromoCode : IEntity
    {
        public Guid Id { get; set; }
        public Guid SessionId { get; set; }

        public string PromoCode { get; set; } // Промокод для фільму
        public decimal DiscountPercentage { get; set; } // Відсоток знижки
        public int MaxUsageCount { get; set; } // Максимальна кількість використань

        public Session Session { get; set; }
        public ICollection<UserSessionPromoCode> UserSessionPromoCodes { get; set; }
    }
}