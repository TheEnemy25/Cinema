using Cinema.Data.Enums;

namespace Cinema.Data.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public Guid CinemaTheaterId { get; set; } // Ідентифікатор кінотеатру, до якого належить працівник

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } // Електронна пошта працівника
        public string PhoneNumber { get; set; } // Номер телефону працівника
        public DateTime DateOfBirth { get; set; } // Дата народження працівника
        public EEmployeeRole Role { get; set; } // Роль працівника (касир, менеджер, і т.д.)

        //Relationships
        public CinemaTheater CinemaTheater { get; set; } // Зв'язок з моделлю Кінотеатром
    }
}
//public string Gender { get; set; } // стать працівника