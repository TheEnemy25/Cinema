namespace Cinema.Data.Entities
{
    public class Country
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; } // Міста, що належать до цієї країни
    }
}
