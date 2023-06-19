using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PawelCarSharing.Models;
using PawelCarSharing.Repositories.Interfaces;

namespace PawelCarSharing.Pages.AccountPanels
{
    public class ClientPanelModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;

        public ClientPanelModel(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Account Account { get; set; }

        public IActionResult OnGet(int id)
        {
            Account = _accountRepository.GetOne(id);

            if (Account == null || Account.AccountRole != Enums.AccountRole.Client) return RedirectToPage("/login");
            else return Page();
        }
    }
}
