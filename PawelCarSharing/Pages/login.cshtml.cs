using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PawelCarSharing.Data;

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
            return RedirectToPage("/Index"); // Przekieruj do strony g³ównej, jeœli u¿ytkownik jest ju¿ zalogowany
        }
    }
}
