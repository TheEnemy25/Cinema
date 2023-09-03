using Cinema.Data.Entities.Interfaces;

namespace Cinema.Data.Entities
{
    // Відгуки
    public class Review : IEntity
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }

        //public string Author { get; set; }
        public string Content { get; set; } // Вміст відгуку
        public int Rating { get; set; } // Рейтинг відгуку
        public DateTime Date { get; set; } // Дата відгуку

        //Relationships
        public Movie Movie { get; set; }
    }
}

// public User User { get; set; } // Зв'язок з користувачем, який залишив відгук
