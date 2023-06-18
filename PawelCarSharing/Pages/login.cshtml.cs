using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PawelCarSharing.Data;
using PawelCarSharing.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PawelCarSharing.Pages
{
    public class loginModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<loginModel> _logger;
        public loginModel(ILogger<loginModel> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }


        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Index"); // Przekieruj do strony g��wnej, je�li u�ytkownik jest ju� zalogowany
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string username, string password)
        {
            if (IsValidLogin(username, password))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    // Dodaj inne roszczenia dla u�ytkownika, je�li s� potrzebne
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    // Dodaj w�a�ciwo�ci uwierzytelniania, je�li s� potrzebne
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToPage("/Index"); // Przekieruj do strony g��wnej po pomy�lnym zalogowaniu
            }
            else
            {
                ViewData["ErrorMessage"] = "Niepoprawna nazwa u�ytkownika lub has�o.";
                return Page();
            }
        }

        private bool IsValidLogin(string login, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Login == login);

            if (user != null)
            {
                // Tutaj mo�esz zaimplementowa� dodatkow� logik�, np. weryfikacj� skr�tu has�a

                return user.Password == password; // Por�wnaj has�o podane przez u�ytkownika z has�em w bazie danych
            }

            return false; // Je�li nie znaleziono u�ytkownika o podanej nazwie
        }

    }
}
