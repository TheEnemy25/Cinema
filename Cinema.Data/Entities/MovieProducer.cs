namespace Cinema.Data.Entities
{
    public class MovieProducer
    {
        public Guid MovieId { get; set; }
        public Guid ProducerId { get; set; }

        public Movie Movie { get; set; }
        public Producer Producer { get; set; }
    }
}
