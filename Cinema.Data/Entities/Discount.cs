﻿using Cinema.Data.Entities.Interfaces;

namespace Cinema.Data.Entities
{
    public class Discount : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }// Назва знижки
        public string Description { get; set; } // Опис знижки, включаючи інформацію про термін дії
        public int Amount { get; set; }// Величина знижки (у відсотках)
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //Relationships
        public ICollection<Session> Sessions { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
