using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PawelCarSharing.Models;
using PawelCarSharing.Repositories.Interfaces;
using PawelCarSharing.Enums;

namespace PawelCarSharing.Pages.AccountPanels
{
    public class AccountAddModel : PageModel
    {
		[BindProperty]
		public Account newAccount { get; set; }
        [BindProperty]
        public string passwordToCompare { get; set; }
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<LoginModel> _logger;

        public AccountAddModel(ILogger<LoginModel> logger, IAccountRepository accountRepository)
        {
            _logger = logger;
            _accountRepository = accountRepository;
        }
        public void OnGet()
		{
		}
		public IActionResult OnPost()
		{
			if (!ModelState.IsValid) return Page();
			if (!newAccount.Password.Equals(passwordToCompare))
			{
				ViewData["ErrorMessage"] = "Has³a rózni¹ siê.";
				return Page();
			}

			_accountRepository.Add(newAccount);
			return RedirectToPage("/AccountManagment/AccountList");
		}
	}
}
