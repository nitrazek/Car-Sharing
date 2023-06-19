using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PawelCarSharing.Models;
using PawelCarSharing.Repositories.Interfaces;

namespace PawelCarSharing.Pages.CarManagment
{
    public class CarAddModel : PageModel
    {
		[BindProperty]
		public Car newCar { get; set; }
        private readonly ICarRepository _carRepository;
        private readonly ILogger<LoginModel> _logger;

        public CarAddModel(ILogger<LoginModel> logger, ICarRepository carRepository)
        {
            _logger = logger;
            _carRepository = carRepository;
        }
        public void OnGet()
        {
        }
		public IActionResult OnPost()
		{
            _carRepository.Add(newCar);

	        return RedirectToPage("/CarManagment/CarList");
		}
	}
}
