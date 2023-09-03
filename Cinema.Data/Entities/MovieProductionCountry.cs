namespace Cinema.Data.Entities
{
    public class MovieProductionCountry
    {
        public Guid MovieId { get; set; }
        public Guid ProductionCountryId { get; set; }

        // Relationships
        public Movie Movie { get; set; }
        public ProductionCountry ProductionCountry { get; set; }
    }
}
