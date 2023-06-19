using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PawelCarSharing.Models;
using PawelCarSharing.Repositories;
using PawelCarSharing.Repositories.Interfaces;

namespace PawelCarSharing.Pages.RentalManagment
{
    public class RentalAddModel : PageModel
    {
        [BindProperty]
        public Rental newRental { get; set; }
        [BindProperty]
        public List<Car> AvailableCars { get; set; }
        [BindProperty]
        public List<Account> AvailableAccounts { get; set; }
        private readonly IRentalRepository _rentalRepository;
        private readonly ICarRepository _carRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<LoginModel> _logger;


        public RentalAddModel(ILogger<LoginModel> logger, IRentalRepository rentalRepository, ICarRepository carRepository, IAccountRepository accountRepository)
        {
            _logger = logger;
            _rentalRepository = rentalRepository;
            _carRepository = carRepository;
            _accountRepository = accountRepository;
        }
        public IActionResult OnGet()
        {
            AvailableCars = _carRepository.GetAll().ToList();
            AvailableAccounts = _accountRepository.GetAll().ToList();
            return Page();
        }

        public IActionResult OnPost()
        {
            List<string> selectedAccountIds = Request.Form["SelectedAccountIds"].ToList();

            foreach (string accountId in selectedAccountIds)
            {
                var account = _accountRepository.GetOne(Int32.Parse(accountId));
                if (account == null) continue;

                AccountRental accountRental = new AccountRental
                {
                    Account = account,
                    Rental = newRental
                };
                newRental.Accounts.Add(accountRental);
            }

            var selectedCarId = Request.Form["CarId"];
            newRental.Car = _carRepository.GetOne(Int32.Parse(selectedCarId));

            _rentalRepository.Add(newRental);

            return RedirectToPage("/RentalManagment/RentalList");
        }

    }
}