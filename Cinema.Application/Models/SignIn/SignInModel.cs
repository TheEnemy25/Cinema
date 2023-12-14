namespace Cinema.Identity.Models.SignIn;

public class SignInModel
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string RedirectUrl { get; set; }
}