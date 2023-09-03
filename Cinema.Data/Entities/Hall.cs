using Cinema.Data.Entities.Interfaces;
using Cinema.Data.Enums;

namespace Cinema.Data.Entities
{
    public class Hall : IEntity
    {
        public Guid Id { get; set; }
        public Guid CinemaTheaterId { get; set; }

        public int Number { get; set; } // Номер залу
        public int Rows { get; set; } // Кількість рядів у залі
        public int SeatsPerRow { get; set; } // Кількість місць у кожному ряді
        public int NormalSeatsCount { get; set; } // Кількість звичайних місць у кінозалі
        public int VIPSeatsCount { get; set; } // Кількість VIP-місць у кінозалі
        public EHallType HallType { get; set; } // Тип залу (Default, 3D, IMAX, VIP)
        public EHallStatus Status { get; set; } // Статус залу
        public decimal BasePrice { get; set; } // Ціна звичайного квитка
        public decimal VIPPrice { get; set; } // Ціна VIP-квитка

        //Relationships
        public CinemaTheater CinemaTheater { get; set; }
        public ICollection<Seat> Seats { get; }
        public ICollection<Session> Sessions { get; set; }
    }
}
// public string HallType { get; set; } // Тип залу (Default, 3D, IMAX, VIP)
