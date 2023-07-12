namespace Cinema.Data.Entities
{
    public class Staff
    {
        public Guid Id { get; set; }
        public Guid CinemaId { get; set; } // Ідентифікатор кінотеатру, до якого належить працівник

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; } // Посада працівника
        public string Email { get; set; } // Електронна пошта працівника
        public string PhoneNumber { get; set; } // Номер телефону працівника
        public DateTime DateOfBirth { get; set; } // Дата народження працівника
        public string Gender { get; set; } // Стать працівника

        public Cinema Cinema { get; set; } // Зв'язок з моделлю "Cinema"
    }
}
