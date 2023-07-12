namespace Cinema.Data.Entities
{
    public class MoviePromoCode
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public Guid DiscountId { get; set; }

        public string PromoCode { get; set; } // Промокод для фільму

        public Movie Movie { get; set; } // Фільм, пов'язаний з промокодом
        public Discount Discount { get; set; } // Знижка, пов'язана з промокодом
    }
}
