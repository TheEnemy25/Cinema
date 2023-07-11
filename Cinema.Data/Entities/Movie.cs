namespace Cinema.Data.Entities
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }//Назва фільму
        public string ImageLink { get; set; }//Зображення
        public string TrailerLink { get; set; }//Трейлер
        public string Rating { get; set; }//Рейтинг
        public string Description { get; set; }//Опис
        public string Genre { get; set; } //Жанр
        public string Country { get; set; } //Країна    
        public string MainActor { get; set; } //Головні актори
        public string Actor { get; set; } //Актор
        public string Director { get; set; } //Режимер
        public string ScreenWriter { get; set; } //Сценарист
        public string Duration { get; set; } //Тривалість
        public string Reviews { get; set; } //Відгуки
    }
}
