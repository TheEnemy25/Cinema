﻿using Cinema.Data.Entities.Interfaces;

namespace Cinema.Data.Entities
{
    public class Actor : IEntity
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }
        public string Image { get; set; }
        public string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }

        //Relationships
        public ICollection<MovieActor> MovieActors { get; set; }
    }
}