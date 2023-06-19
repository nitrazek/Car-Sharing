using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PawelCarSharing.Models;
using PawelCarSharing.Repositories.Interfaces;

namespace PawelCarSharing.Pages.CarManagment
{
    public class CarListModel : PageModel
    {
        public List<Car> carList;
        private readonly ICarRepository _carRepository;
        private readonly ILogger<LoginModel> _logger;

        public CarListModel(ILogger<LoginModel> logger, ICarRepository carRepository)
        {
            _logger = logger;
            _carRepository = carRepository;
        }

        public IActionResult OnGet()
        {
            carList = _carRepository.GetAll();
            return Page();
        }
    }
}
