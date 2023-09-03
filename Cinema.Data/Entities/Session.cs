﻿namespace Cinema.Data.Entities
{
    public class Session
    {
        public Guid Id { get; set; }
        public Guid HallId { get; set; }
        public Guid MovieId { get; set; }
        public Guid DiscountId { get; set; }

        public DateTime Date { get; set; } // Дата сеансу
        public TimeSpan StartTime { get; set; }

        // Relationships
        public Hall Hall { get; set; }
        public Movie Movie { get; set; }
        public Discount Discount { get; set; }
        public ICollection<SessionSeat> SessionSeats { get; set; }
        public ICollection<Ticket> Tickets { get; set; } // Зв'язок з пропусками
    }
}

//public int AvailableSeatsCount { get; set; } // Кількість вільних місць на сеансі
