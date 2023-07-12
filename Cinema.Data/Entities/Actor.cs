namespace Cinema.Data.Entities
{
    //Актор
    public class Actor
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Image { get; set; }
        public string Biography { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
