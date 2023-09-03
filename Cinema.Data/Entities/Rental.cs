﻿namespace Cinema.Data.Entities
{
    public class Rental
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public Guid CinemaTheaterId { get; set; } 

        public DateTime RentalDate { get; set; } // Дата прокату

        public Movie Movie { get; set; }
        public CinemaTheater CinemaTheater { get; set; } 
    }
}
