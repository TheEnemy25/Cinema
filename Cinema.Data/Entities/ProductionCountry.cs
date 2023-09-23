using Cinema.Data.Entities.Interfaces;

namespace Cinema.Data.Entities
{
    public class ProductionCountry : IEntity
    {
        public Guid Id { get; set; }

        public string CountryName { get; set; }

        // Relationships
        public ICollection<MovieProductionCountry> MovieProductionCountries { get; set; }
    }
}
