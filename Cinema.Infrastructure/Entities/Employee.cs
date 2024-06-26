﻿using Cinema.Infrastructure.Entities.Interfaces;
using Cinema.Infrastructure.Enums;

namespace Cinema.Infrastructure.Entities
{
    public class Employee : IEntityWithId
    {
        public Guid Id { get; set; }
        public Guid CinemaTheaterId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } 
        public string PhoneNumber { get; set; } // Номер телефону працівника
        public DateTime DateOfBirth { get; set; } // Дата народження працівника
        public EEmployeeRole Role { get; set; } // Роль працівника (касир, менеджер, і т.д.)

        //Relationships
        public CinemaTheater CinemaTheater { get; set; }
    }
}