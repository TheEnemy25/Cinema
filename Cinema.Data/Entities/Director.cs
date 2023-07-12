namespace Cinema.Data.Entities
{
    //Режисер
    public class Director 
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Image { get; set; }
        public string Biography { get; set; }
        public string Age { get; set; }
    }
}
