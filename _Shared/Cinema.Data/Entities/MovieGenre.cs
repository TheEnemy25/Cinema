using Cinema.Data.Entities.Interfaces;

namespace Cinema.Data.Entities
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
