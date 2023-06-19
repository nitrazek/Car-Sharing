using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PawelCarSharing.Models;
using PawelCarSharing.Repositories.Interfaces;

namespace PawelCarSharing.Pages.AccountPanels
{
    public class WorkerPanelModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;

        public WorkerPanelModel(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Account Account { get; set; }

        public IActionResult OnGet(int id)
        {
            Account = _accountRepository.GetOne(id);

            if (Account == null || Account.AccountRole != Enums.AccountRole.Worker) return RedirectToPage("/login");
            else return Page();
        }
    }
}
