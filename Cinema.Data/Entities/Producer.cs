using Cinema.Data.Entities.Interfaces;

namespace Cinema.Data.Entities
{
    //Продюсер
    public class Producer : IEntity
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }
        public string Image { get; set; }
        public string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ICollection<MovieProducer> MovieProducers { get; set; } // Зв'язок багато до багатьох з фільмами
    }
}

