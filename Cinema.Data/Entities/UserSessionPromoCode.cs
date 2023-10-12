using Cinema.Data.Entities.Interfaces;

namespace Cinema.Data.Entities
{
    public class UserSessionPromoCode : IEntity
    {
        public string UserId { get; set; }
        public Guid SessionPromoCodeId { get; set; }

        public DateTime UsageDate { get; set; }

        public AppUser User { get; set; }
        public SessionPromoCode SessionPromoCode { get; set; }
    }
}
