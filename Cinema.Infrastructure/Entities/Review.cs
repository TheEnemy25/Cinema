using Cinema.Infrastructure.Entities.Interfaces;

namespace Cinema.Infrastructure.Entities
{
    // Відгуки
    public class Review : IEntity
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public Guid UserId { get; set; }

        public string Content { get; set; } // Вміст відгуку
        public int Rating { get; set; } // Рейтинг відгуку
        public DateTime Date { get; set; } // Дата відгуку

        //Relationships
        public Movie Movie { get; set; }
        public AppUser User { get; set; }
    }
}