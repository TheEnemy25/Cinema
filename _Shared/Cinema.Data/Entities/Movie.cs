using Cinema.Data.Entities.Interfaces;

namespace Cinema.Data.Entities
{
    public class Movie : IEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; }//Назва фільму
        public int AgeRestriction { get; set; } // Вікове обмеження фільму
        public string Description { get; set; }//Опис
        public string ImageLink { get; set; }//Зображення
        public string TrailerLink { get; set; }//Трейлер
        public double Rating { get; set; }//Рейтинг
        public TimeSpan Duration { get; set; } //Тривалість фільму
        public DateTime ReleaseDate { get; set; } // Дата випуску фільму

        // Relationships
        public ICollection<MovieDirector> MovieDirectors { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; }
        public ICollection<MovieGenre> MovieGenres { get; set; }
        public ICollection<MovieProducer> MovieProducers { get; set; }
        public ICollection<MovieScreenwriter> MovieScreenwriters { get; set; }
        public ICollection<MovieStudio> MovieStudios { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Session> Sessions { get; set; }
        public ICollection<Rental> Rentals { get; set; }
        public ICollection<MovieProductionCountry> MovieProductionCountries { get; set; }
    }
}