using Cinema.Data.Entities.Interfaces;

namespace Cinema.Data.Entities
{
    public class Genre : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }

        //Relationships
        public ICollection<MovieGenre> MovieGenres { get; set; } // Зв'язки між жанрами і фільмами
    }
}
