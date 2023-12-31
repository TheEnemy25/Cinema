﻿using Cinema.Infrastructure.Entities.Interfaces;

namespace Cinema.Infrastructure.Entities
{
    public class MovieDirector : IEntity
    {
        public Guid MovieId { get; set; }
        public Guid DirectorId { get; set; }

        //Relationships
        public Movie Movie { get; set; }
        public Director Director { get; set; }
    }
}
