namespace Cinema.Data.Entities
{
    public class Movie
    {
        public Guid Id { get; set; }
        public Guid DirectorId { get; set; } // Зовнішній ключ для режисера

        public string Title { get; set; }//Назва фільму
        public string Description { get; set; }//Опис
        public string ImageLink { get; set; }//Зображення
        public string TrailerLink { get; set; }//Трейлер
        public double Rating { get; set; }//Рейтинг
        public string Duration { get; set; } //Тривалість

        public List<string> ProductionCountries { get; set; } // Країни виробництва




        public Director Director { get; set; } // Зв'язок з моделлю "Director"

        public ICollection<MovieActor> MovieActors { get; set; }
        public ICollection<MovieGenre> MovieGenres { get; set; } // Зв'язки між жанрами і фільмами
        public ICollection<MovieProducer> MovieProducers { get; set; } // Зв'язок багато до багатьох з продюсерами
        public ICollection<MovieScreenwriter> MovieScreenwriters { get; set; } // Зв'язок багато до багатьох з сценаристами
        public ICollection<Review> Reviews { get; set; } // Відгуки про фільм
    }
}
