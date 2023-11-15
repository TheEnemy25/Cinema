using Cinema.Data.Entities.Interfaces;

namespace Cinema.Data.Entities
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
