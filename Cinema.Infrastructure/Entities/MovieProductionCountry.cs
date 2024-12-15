using Cinema.Infrastructure.Entities.Interfaces;

namespace Cinema.Infrastructure.Entities
{
    public class MovieProductionCountry : IEntity
    {
        public Guid MovieId { get; set; }
        public Guid ProductionCountryId { get; set; }

        // Relationships
        public Movie Movie { get; set; }
        public ProductionCountry ProductionCountry { get; set; }
    }
}
