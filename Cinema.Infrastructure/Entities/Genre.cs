using Cinema.Infrastructure.Entities.Interfaces;

namespace Cinema.Infrastructure.Entities
{
    public class Genre : IEntityWithId
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }

        //Relationships
        public ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
