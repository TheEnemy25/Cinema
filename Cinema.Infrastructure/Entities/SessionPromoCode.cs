﻿using Cinema.Infrastructure.Entities.Interfaces;

namespace Cinema.Infrastructure.Entities
{
    public class SessionPromoCode : IEntityWithId
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