using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PawelCarSharing.Repositories.Interfaces;

namespace PawelCarSharing.Pages.AccountPanels
{
    public class AccountDeleteModel : PageModel
    {
		[BindProperty(SupportsGet = true)]
		public int id { get; set; }
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<LoginModel> _logger;

        public AccountDeleteModel(ILogger<LoginModel> logger, IAccountRepository accountRepository)
        {
            _logger = logger;
            _accountRepository = accountRepository;
        }
        public IActionResult OnGet()
		{
            _accountRepository.Delete(id);
            return RedirectToPage("/AccountManagment/AccountList");
		}
	}
}
