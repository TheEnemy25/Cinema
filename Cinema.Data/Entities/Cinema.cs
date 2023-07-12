namespace Cinema.Data.Entities
{
    public class Cinema
    {
        public Guid Id { get; set; }
        public Guid CityId { get; set; }

        public string Address { get; set; }
        public string ContactInfo { get; set; }

        public City City { get; set; }
    }
}
