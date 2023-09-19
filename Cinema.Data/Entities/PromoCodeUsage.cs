using Cinema.Data.Entities.Interfaces;

namespace Cinema.Data.Entities
{
    public class PromoCodeUsage : IEntity
    {
        public Guid Id { get; set; }
        public Guid SessionPromoCodeId { get; set; }
        public Guid ProductPromoCodeId { get; set; }

        public DateTime UsageDate { get; set; } // Дата використання

        // Relationships
        public SessionPromoCode SessionPromoCode { get; set; } // Зв'язок з MoviePromoCode
        public ProductPromoCode ProductPromoCode { get; set; } // Зв'язок з MoviePromoCode
    }
}
