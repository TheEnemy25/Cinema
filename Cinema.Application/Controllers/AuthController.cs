using Cinema.Application.Entities;
using Cinema.Application.Models.Register;
using Cinema.Application.Models.SignIn;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Application.Controllers
{
    [AllowAnonymous]
    [Route("~/auth")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IIdentityServerInteractionService _identityServerService;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IIdentityServerInteractionService identityServerService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _identityServerService = identityServerService;
        }

        [HttpPut("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationModel registrationModel)
        {
            var user = new AppUser
            {
                Email = registrationModel.Email,
                FirstName = registrationModel.FirstName,
                LastName = registrationModel.LastName
            };

            var result = await _userManager.CreateAsync(user, registrationModel.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Redirect(registrationModel.RedirectUrl);
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] SignInModel signInModel)
        {
            var user = await _userManager.FindByEmailAsync(signInModel.Email);

            if (user is not null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, signInModel.Password, false, false);

                if (result.Succeeded)
                {
                    return Redirect(signInModel.RedirectUrl);
                }

                return BadRequest("Failed sign-in attempt");
            }

            return BadRequest("User not found");
        }

        [HttpGet("sign-out")]
        public async Task<IActionResult> SignOut([FromQuery] string logoutId)
        {
            await _signInManager.SignOutAsync();
            var logoutRequest = await _identityServerService.GetLogoutContextAsync(logoutId);

            return Redirect(logoutRequest.PostLogoutRedirectUri);
        }
    }
}