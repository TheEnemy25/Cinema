namespace Cinema.Data.Entities
{
    public class Country
    {
        public Guid Id { get; set; }
        public string Name { get; set; } // Назва країни
        public string CountryCode { get; set; } // Код країни (наприклад, UA для України, US для США)

        //Relationships
        public ICollection<City> Cities { get; set; } // Міста, що належать до цієї країни
    }
}
