namespace Cinema.Data.Entities
{
    public class Receipt
    {
        public Guid Id { get; set; }
        public decimal TotalPrice { get; set; }
        public string PaymentType { get; set; }
        public DateTime DateTime { get; set; }
    }
}
