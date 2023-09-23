namespace Cinema.Application.Models.SignIn;

public class SignInModel
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string RedirectUrl { get; set; } = null!;
}