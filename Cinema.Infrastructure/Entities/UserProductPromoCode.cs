using Cinema.Infrastructure.Entities.Interfaces;

namespace Cinema.Infrastructure.Entities
{
    public class UserProductPromoCode : IEntityWithId
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductPromoCodeId { get; set; }

        public DateTime UsageDate { get; set; }

        public AppUser User { get; set; }
        public ProductPromoCode ProductPromoCode { get; set; }
    }
}
