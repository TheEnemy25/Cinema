namespace Cinema.Data.Entities
{
    public class Review
    {
        public Guid Id { get; set; }
        public string Author { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
