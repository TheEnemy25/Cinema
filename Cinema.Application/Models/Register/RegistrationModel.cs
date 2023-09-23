namespace Cinema.Application.Models.Register
{
    public class RegistrationModel
    {
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string RedirectUrl { get; set; } = null!;
    }
}