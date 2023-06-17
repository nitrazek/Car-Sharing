using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PawelCarSharing.Pages
{
    public class loginModel : PageModel
    {
        private readonly ILogger<loginModel> _logger;

        public loginModel(ILogger<loginModel> logger)
        {
            _logger = logger;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost(string username, string password)
        {
            if (IsValidLogin(username, password))
            {
                return RedirectToPage(""); //Gdzieœ ma przenieœæ
            }
            else
            {
                ViewData["ErrorMessage"] = "Niepoprawna nazwa u¿ytkownika lub has³o.";
                return Page();
            }
        }
        private bool IsValidLogin(string username, string password)
        {
            //Jakaœ walidacja
            return false;
        }
    }
}
