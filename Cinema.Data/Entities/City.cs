using Cinema.Data.Entities.Interfaces;

namespace Cinema.Data.Entities
{
    public class City : IEntity
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }

        public string Name { get; set; }

        //Relationships
        public Country Country { get; set; }
        public ICollection<CinemaTheater> CinemaTheaters { get; set; }
    }
}
