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
                return RedirectToPage("/Index"); // Przekieruj do strony g³ównej, jeœli u¿ytkownik jest ju¿ zalogowany
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
                    // Dodaj inne roszczenia dla u¿ytkownika, jeœli s¹ potrzebne
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    // Dodaj w³aœciwoœci uwierzytelniania, jeœli s¹ potrzebne
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToPage("/Index"); // Przekieruj do strony g³ównej po pomyœlnym zalogowaniu
            }
            else
            {
                ViewData["ErrorMessage"] = "Niepoprawna nazwa u¿ytkownika lub has³o.";
                return Page();
            }
        }

        private bool IsValidLogin(string login, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Login == login);

            if (user != null)
            {
                // Tutaj mo¿esz zaimplementowaæ dodatkow¹ logikê, np. weryfikacjê skrótu has³a

                return user.Password == password; // Porównaj has³o podane przez u¿ytkownika z has³em w bazie danych
            }

            return false; // Jeœli nie znaleziono u¿ytkownika o podanej nazwie
        }

    }
}
