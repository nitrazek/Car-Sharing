using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PawelCarSharing.Repositories.Interfaces;

namespace PawelCarSharing.Pages.RentalManagment
{
    public class RentalDeleteModel : PageModel
    {
		[BindProperty(SupportsGet = true)]
		public int id { get; set; }
        private readonly IRentalRepository _rentalRepository;
        private readonly ILogger<LoginModel> _logger;

        public RentalDeleteModel(ILogger<LoginModel> logger, IRentalRepository rentalRepository)
        {
            _logger = logger;
            _rentalRepository = rentalRepository;
        }
        public IActionResult OnGet()
		{
            _rentalRepository.Delete(id);
            return RedirectToPage("/RentalManagment/RentalList");
		}
	}
}
