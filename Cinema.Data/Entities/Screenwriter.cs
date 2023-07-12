namespace Cinema.Data.Entities
{
    public class Screenwriter
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Image { get; set; }
        public string Biography { get; set; }
        public DateTime BirthDate { get; set; }

        public ICollection<MovieScreenwriter> MovieScreenwriters { get; set; } // Зв'язок багато до багатьох з фільмами
    }
}
