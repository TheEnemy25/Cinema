namespace Cinema.Data.Entities
{
    public class Studio
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<MovieStudio> MovieStudios { get; set; } // Зв'язок багато до багатьох з фільмами
    }
}