using Cinema.Data.Entities.Interfaces;

namespace Cinema.Data.Entities
{
    public class Studio : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public ICollection<MovieStudio> MovieStudios { get; set; } // Зв'язок багато до багатьох з фільмами
    }
}