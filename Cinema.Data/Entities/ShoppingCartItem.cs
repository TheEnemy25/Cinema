﻿namespace Cinema.Data.Entities
{
    public class ShoppingCartItem
    {
        public Guid Id { get; set; }
        public Guid ShoppingCartId { get; set; }
        public Guid TicketId { get; set; }
        public Guid ProductId { get; set; }
        public Guid SeatId { get; set; }

        public int Quantity { get; set; } // Кількість одиниць товару
        public decimal UnitPrice { get; set; } // Вартість одиниці товару

        // Relationships
        public ShoppingCart ShoppingCart { get; set; } // Зв'язок з кошиком
        public Ticket Ticket { get; set; }
        public Product Product { get; set; }
        public Seat Seat { get; set; }
    }
}
