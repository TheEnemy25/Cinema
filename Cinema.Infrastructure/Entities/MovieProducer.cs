using Cinema.Infrastructure.Entities.Interfaces;

namespace Cinema.Infrastructure.Entities
{
    public class MovieProducer : IEntity
    {
        public Guid MovieId { get; set; }
        public Guid ProducerId { get; set; }

        //Relationships
        public Movie Movie { get; set; }
        public Producer Producer { get; set; }
    }
}
