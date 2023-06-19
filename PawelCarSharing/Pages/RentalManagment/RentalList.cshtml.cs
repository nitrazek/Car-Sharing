using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PawelCarSharing.Models;
using PawelCarSharing.Repositories.Interfaces;

namespace PawelCarSharing.Pages.RentalManagment
{
    public class RentalListModel : PageModel
    {
        public List<Rental> rentalList;
        private readonly IRentalRepository _rentalRepository;
        private readonly ILogger<LoginModel> _logger;

        public RentalListModel(ILogger<LoginModel> logger, IRentalRepository rentalRepository)
        {
            _logger = logger;
            _rentalRepository = rentalRepository;
        }

        public IActionResult OnGet()
        {
            rentalList = _rentalRepository.GetAll();
            return Page();
        }
    }
}
