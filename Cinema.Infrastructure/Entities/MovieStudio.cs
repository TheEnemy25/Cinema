using Cinema.Infrastructure.Entities.Interfaces;

namespace Cinema.Infrastructure.Entities
{
    public class MovieStudio : IEntity
    {
        public Guid MovieId { get; set; }
        public Guid StudioId { get; set; }

        //Relationships
        public Movie Movie { get; set; }
        public Studio Studio { get; set; }
    }
}
