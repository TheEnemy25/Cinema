namespace Cinema.Data.Entities
{
    public class MovieGenre
    {
        public Guid MovieId { get; set; } // Ідентифікатор фільму
        public Guid GenreId { get; set; } // Ідентифікатор жанру

        //Relationships
        public Movie Movie { get; set; } // Зв'язок з моделлю "Movie"
        public Genre Genre { get; set; } // Зв'язок з моделлю "Genre"
    }
}
