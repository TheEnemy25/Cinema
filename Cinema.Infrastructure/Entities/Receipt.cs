﻿using Cinema.Infrastructure.Entities.Interfaces;

namespace Cinema.Infrastructure.Entities
{
    //Квиток
    public class Receipt : IEntityWithId
    {
        public Guid Id { get; set; }
        public Guid ShoppingCartId { get; set; }

        public decimal TotalAmount { get; set; } // Загальна сума
        public DateTime CreatedAt { get; set; }

        //Relationship
        public ShoppingCart ShoppingCart { get; set; }
        public ICollection<Ticket> Tickets { get; set; } // Зв'язок з перепустками
    }
}
