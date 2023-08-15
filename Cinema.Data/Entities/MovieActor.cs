namespace Cinema.Data.Entities
{
    public class MovieActor
    {
        public Guid MovieId { get; set; }
        public Guid ActorId { get; set; }

        //Relationships
        public Movie Movie { get; set; }
        public Actor Actor { get; set; }
    }
}
 