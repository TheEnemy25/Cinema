namespace Cinema.Data.Entities
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }

        public ICollection<MovieGenre> MovieGenres { get; set; } // Зв'язки між жанрами і фільмами
    }
}
