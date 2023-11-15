using Cinema.Data.Entities.Interfaces;

namespace Cinema.Data.Entities
{
    //Сценарист
    public class Screenwriter : IEntity
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }
        public string Image { get; set; }
        public string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }

        //Relationships
        public ICollection<MovieScreenwriter> MovieScreenwriters { get; set; }
    }
}