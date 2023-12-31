﻿using Cinema.Infrastructure.Entities.Interfaces;

namespace Cinema.Infrastructure.Entities
{
    public class MovieScreenwriter : IEntity
    {
        public Guid MovieId { get; set; }
        public Guid ScreenwriterId { get; set; }

        //Relationships
        public Movie Movie { get; set; }
        public Screenwriter Screenwriter { get; set; }
    }
}
