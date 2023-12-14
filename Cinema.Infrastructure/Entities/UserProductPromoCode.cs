using Cinema.Infrastructure.Entities.Interfaces;

namespace Cinema.Infrastructure.Entities
{
    public class UserProductPromoCode : IEntity
    {
        public string UserId { get; set; }
        public Guid ProductPromoCodeId { get; set; }

        public DateTime UsageDate { get; set; }

        public AppUser User { get; set; }
        public ProductPromoCode ProductPromoCode { get; set; }
    }
}
