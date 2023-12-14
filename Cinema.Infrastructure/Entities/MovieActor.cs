using Cinema.Infrastructure.Entities.Interfaces;

namespace Cinema.Infrastructure.Entities
{
    public class MovieActor : IEntity
    {
        public Guid MovieId { get; set; }
        public Guid ActorId { get; set; }

        //Relationships
        public Movie Movie { get; set; }
        public Actor Actor { get; set; }
    }
}
