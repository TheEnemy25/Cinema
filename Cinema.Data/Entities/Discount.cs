namespace Cinema.Data.Entities
{
    public class Discount
    {
        public Guid Id { get; set; }
        public string Name { get; set; }// Назва знижки
        public string Description { get; set; } // Опис знижки, включаючи інформацію про термін дії
        public int Amount { get; set; }// Величина знижки (у відсотках)
        public DateTime StartDate { get; set; } // Дата початку дії знижки
        public DateTime EndDate { get; set; } // Дата закінчення дії знижки


        public ICollection<MovieDiscount> MovieDiscounts { get; set; } // Зв'язок багато до багатьох з фільмами
        public ICollection<ProductDiscount> ProductDiscounts { get; set; } // Зв'язок багато до багатьох з продуктами
    }
}
