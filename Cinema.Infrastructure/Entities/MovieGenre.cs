using Cinema.Infrastructure.Entities.Interfaces;

namespace Cinema.Infrastructure.Entities
{
    public class MovieGenre : IEntity
    {
        public Guid MovieId { get; set; }
        public Guid GenreId { get; set; }

        //Relationships
        public Movie Movie { get; set; }
        public Genre Genre { get; set; }
    }
}
