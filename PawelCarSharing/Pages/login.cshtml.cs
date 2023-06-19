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
            if (!User.Identity.IsAuthenticated) return Page();
            
            string Role = User.FindFirstValue(ClaimTypes.Role);
            string Id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (Role == null || Id == null) return Page();

            switch (Role)
            {
                case "Client":
                    return RedirectToPage("/RolePanel/ClientPanel", new { id = Id });
                case "Worker":
                    return RedirectToPage("/RolePanel/WorkerPanel", new { id = Id });
                case "Administrator":
                    return RedirectToPage("/RolePanel/AdminPanel", new { id = Id });
                default:
                    ViewData["ErrorMessage"] = "Nieprawid³owa rola";
                    return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = _accountRepository.GetAccountByLoginAndPassword(Username, Password);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Login),
                    new Claim(ClaimTypes.Role, user.AccountRole.ToString())
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                switch(user.AccountRole)
                {
                    case Enums.AccountRole.Client:
                        return RedirectToPage("/RolePanel/ClientPanel", new { id = user.Id });
                    case Enums.AccountRole.Worker:
                        return RedirectToPage("/RolePanel/WorkerPanel", new { id = user.Id });
                    case Enums.AccountRole.Administrator:
                        return RedirectToPage("/RolePanel/AdminPanel", new { id = user.Id });
                    default:
                        ViewData["ErrorMessage"] = "Nieprawid³owa rola";
                        return Page();
                }
            }

            ViewData["ErrorMessage"] = "Nieprawid³owe dane logowania.";
            return Page();
        }

        public async Task<IActionResult> OnGetLogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/login");
        }
    }
}
