using Cinema.Infrastructure.Entities.Interfaces;

namespace Cinema.Infrastructure.Entities
{
    //Продюсер
    public class Producer : IEntity
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }
        public string Image { get; set; }
        public string Biography { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ICollection<MovieProducer> MovieProducers { get; set; }
    }
}

