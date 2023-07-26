namespace Cinema.Data.Entities
{
    public class MovieRental
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; } // Зовнішній ключ для фільму
        public Guid CinemaId { get; set; } // Зовнішній ключ для кінотеатру

        public DateTime RentalDate { get; set; } // Дата прокату

        public Movie Movie { get; set; } // Зв'язок з моделлю "Movie"
        public Cinema Cinema { get; set; } // Зв'язок з моделлю "Cinema"
    }
}
