using Cinema.Infrastructure.Entities.Interfaces;

namespace Cinema.Infrastructure.Entities
{
    //Сценарист
    public class Screenwriter : IEntityWithId
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }
        public string Image { get; set; }
        public string Biography { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }

        //Relationships
        public ICollection<MovieScreenwriter> MovieScreenwriters { get; set; }
    }
}