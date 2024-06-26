﻿using Cinema.Infrastructure.Entities.Interfaces;

namespace Cinema.Infrastructure.Entities
{
    public class ProductionCountry : IEntityWithId
    {
        public Guid Id { get; set; }

        public string CountryName { get; set; }

        // Relationships
        public ICollection<MovieProductionCountry> MovieProductionCountries { get; set; }
    }
}
