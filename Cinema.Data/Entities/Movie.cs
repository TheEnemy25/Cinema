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
        public ICollection<MovieDirector> MovieDirectors { get; set; }// Зв'язок з акторами
        public ICollection<MovieActor> MovieActors { get; set; }// Зв'язок з акторами
        public ICollection<MovieGenre> MovieGenres { get; set; } // Зв'язки між жанрами і фільмами
        public ICollection<MovieProducer> MovieProducers { get; set; } // Зв'язок багато до багатьох з продюсерами
        public ICollection<MovieScreenwriter> MovieScreenwriters { get; set; } // Зв'язок багато до багатьох з сценаристами
        public ICollection<MovieStudio> MovieStudios { get; set; } // Зв'язок багато до багатьох зі студіями
        public ICollection<Review> Reviews { get; set; } // Відгуки про фільм
        public ICollection<Session> Sessions { get; set; }// Зв'язок з сеансами
        public ICollection<MoviePromoCode> MoviePromoCodes { get; set; } // Зв'язок з промокодами фільму
        public ICollection<Rental> Rentals { get; set; } // Зв'язок з промокодами фільму
        public ICollection<MovieProductionCountry> MovieProductionCountries { get; set; }// Країни виробництва
    }
}