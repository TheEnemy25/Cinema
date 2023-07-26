namespace Cinema.Data.Entities
{
    public class Receipt
    {
        public Guid Id { get; set; }
        public decimal TotalPrice { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
