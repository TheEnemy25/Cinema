﻿using Cinema.Infrastructure.Entities.Interfaces;

namespace Cinema.Infrastructure.Entities
{
    public class UserSessionPromoCode : IEntityWithId
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid SessionPromoCodeId { get; set; }

        public DateTime UsageDate { get; set; }

        public AppUser User { get; set; }
        public SessionPromoCode SessionPromoCode { get; set; }
    }
}
