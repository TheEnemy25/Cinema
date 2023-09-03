namespace Cinema.Data.Entities
{
    //Режисер
    public class Director
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Image { get; set; }
        public string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }

        // Relationships
        public ICollection<MovieDirector> MovieDirectors { get; set; } // Зв'язок з фільмами, які режисер зняв
    }
}
