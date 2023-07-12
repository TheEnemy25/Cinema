namespace Cinema.Data.Entities
{
    public class Cinema
    {
        public Guid Id { get; set; }
        public string Adress { get; set; }
        public City City { get; set; }
    }
}
