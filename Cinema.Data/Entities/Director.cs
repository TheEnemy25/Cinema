using Cinema.Data.Entities.Interfaces;

namespace Cinema.Data.Entities
{
    //Режисер
    public class Director : IEntity
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Image { get; set; }
        public string Biography { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }

        // Relationships
        public ICollection<MovieDirector> MovieDirectors { get; set; }
    }
}
