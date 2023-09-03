using Cinema.Data.Entities.Interfaces;

namespace Cinema.Data.Entities
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
