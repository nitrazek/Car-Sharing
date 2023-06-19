using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PawelCarSharing.Models;
using PawelCarSharing.Repositories.Interfaces;

namespace PawelCarSharing.Pages.AccountManagment
{
    public class AccountListModel : PageModel
    {
        public List<Account> accountList;
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<LoginModel> _logger;

        public AccountListModel(ILogger<LoginModel> logger, IAccountRepository accountRepository)
        {
            _logger = logger;
            _accountRepository = accountRepository;
        }

        public IActionResult OnGet()
        {
            accountList = _accountRepository.GetAll();
            return Page();
        }
    }
}
