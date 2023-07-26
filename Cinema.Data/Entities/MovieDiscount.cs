namespace Cinema.Data.Entities
{
    public class MovieDiscount
    {
        public Guid MovieId { get; set; } // Зовнішній ключ для фільму
        public Guid DiscountId { get; set; } // Зовнішній ключ для знижки

        public Movie Movie { get; set; }
        public Discount Discount { get; set; }
    }
}
