namespace Cinema.Data.Entities
{
    public class City
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }

        public string Name { get; set; }

        //Relationships
        public Country Country { get; set; } 
        public ICollection<CinemaTheater> CinemaTheaters { get; set; } 
    }
}
