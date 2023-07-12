namespace Cinema.Data.Entities
{
    public class City
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }


        public string Name { get; set; }
        public string District { get; set; }
        public string Street { get; set; }

        public Country Country { get; set; } 
        public ICollection<Cinema> Cinemas { get; set; } 
    }
}
