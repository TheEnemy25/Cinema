﻿namespace Cinema.Data.Entities
{
    public class MovieStudio
    {
        public Guid MovieId { get; set; }
        public Guid StudioId { get; set; }

        //Relationships
        public Movie Movie { get; set; }
        public Studio Studio { get; set; }
    }
}
