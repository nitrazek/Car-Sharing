using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PawelCarSharing.Models;
using PawelCarSharing.Repositories.Interfaces;

namespace PawelCarSharing.Pages.AccountPanels
{
    public class AccountEditModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int id { get; set; }
        [BindProperty]
        public Account accountToEdit { get; set; }
        [BindProperty]
        public string passwordToCompare { get; set; }
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<LoginModel> _logger;

        public AccountEditModel(ILogger<LoginModel> logger, IAccountRepository accountRepository)
        {
            _logger = logger;
            _accountRepository = accountRepository;
        }
        public IActionResult OnGet()
        {
            accountToEdit = _accountRepository.GetOne(id);
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            if (!accountToEdit.Password.Equals(passwordToCompare))
            {
                ViewData["ErrorMessage"] = "Has³a rózni¹ siê.";
                return Page();
            }
            accountToEdit.Id = id;
            _accountRepository.Update(accountToEdit);
            return RedirectToPage("/AccountManagment/AccountList");
        }
    }
}
