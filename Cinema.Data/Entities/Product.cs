namespace Cinema.Data.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public ICollection<ProductDiscount> ProductDiscount { get; set; } // Зв'язок багато до багатьох зі знижками
    }
}