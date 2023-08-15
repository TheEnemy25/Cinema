namespace Cinema.Data.Entities
{
    public class MovieScreenwriter
    {
        public Guid MovieId { get; set; }
        public Guid ScreenwriterId { get; set; }

        //Relationships
        public Movie Movie { get; set; }
        public Screenwriter Screenwriter { get; set; }
    }
}
