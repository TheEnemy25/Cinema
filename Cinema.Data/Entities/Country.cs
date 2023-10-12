﻿using Cinema.Data.Entities.Interfaces;

namespace Cinema.Data.Entities
{
    public class Country : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; } // Код країни (наприклад, UA для України, US для США)

        //Relationships
        public ICollection<City> Cities { get; set; }
    }
}
