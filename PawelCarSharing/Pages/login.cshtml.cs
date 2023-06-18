using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PawelCarSharing.Repositories.Interfaces;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PawelCarSharing.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(ILogger<LoginModel> logger, IAccountRepository accountRepository)
        {
            _logger = logger;
            _accountRepository = accountRepository;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public IActionResult OnGet()
        {
            // SprawdŸ, czy u¿ytkownik jest ju¿ uwierzytelniony
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // SprawdŸ, czy u¿ytkownik o podanym username i password istnieje w bazie danych
            var user = _accountRepository.GetAccountByLoginAndPassword(Username, Password);

            if (user != null)
            {
                // Utwórz listê claimów dla uwierzytelnienia u¿ytkownika
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Login),
                    // Dodaj inne claimy, jeœli s¹ wymagane
                };

                // Utwórz obiekt ClaimsIdentity z list¹ claimów
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Uwierzytelnij u¿ytkownika i zapisz uwierzytelnione dane w ciasteczkach
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                return RedirectToPage("/Privacy");
            }

            // Jeœli uwierzytelnianie nie powiod³o siê, przekieruj na stronê logowania
            ViewData["ErrorMessage"] = "Nieprawid³owe dane logowania.";
            return Page();
        }

        public async Task<IActionResult> OnGetLogoutAsync()
        {
            // Wyloguj u¿ytkownika
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToPage("/Index");
        }
    }
}
