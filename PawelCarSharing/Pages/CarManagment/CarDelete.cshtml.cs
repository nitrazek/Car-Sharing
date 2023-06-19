using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PawelCarSharing.Repositories.Interfaces;

namespace PawelCarSharing.Pages.CarManagment
{
    public class CarDeleteModel : PageModel
    {
		[BindProperty(SupportsGet = true)]
		public int id { get; set; }
        private readonly ICarRepository _carRepository;
        private readonly ILogger<LoginModel> _logger;

        public CarDeleteModel(ILogger<LoginModel> logger, ICarRepository carRepository)
        {
            _logger = logger;
            _carRepository = carRepository;
        }
        public IActionResult OnGet()
		{
            _carRepository.Delete(id);
            return RedirectToPage("/CarManagment/CarList");
		}
	}
}
