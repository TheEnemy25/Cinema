namespace Cinema.Application.Models.Register
{
    public class RegistrationModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string RedirectUrl { get; set; }
    }
}