namespace Cinema.Data.Entities
{
    public class CinemaTheater
    {
        public Guid Id { get; set; }
        public Guid CityId { get; set; }

        public string Address { get; set; }
        public string ContactInfo { get; set; }

        //Relationships
        public City City { get; set; }
        public ICollection<Hall> Halls { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
