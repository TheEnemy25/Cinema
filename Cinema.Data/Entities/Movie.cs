using System.Diagnostics.Metrics;

namespace Cinema.Data.Entities
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }//Назва фільму
        public string ImageLink { get; set; }//Зображення
        public string TrailerLink { get; set; }//Трейлер
        public double Rating { get; set; }//Рейтинг
        public string Description { get; set; }//Опис
        public string Genre { get; set; } //Жанр
        public List<string> ProductionCountries { get; set; } // Країни виробництва
        public string Actor { get; set; } //Актор
        public string Director { get; set; } //Режисер
        public string ScreenWriter { get; set; } //Сценарист
        public string Duration { get; set; } //Тривалість
        public Review Review { get; set; } //Відгуки
    }
}
