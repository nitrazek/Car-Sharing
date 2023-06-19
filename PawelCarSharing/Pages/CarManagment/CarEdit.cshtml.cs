using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PawelCarSharing.Models;
using PawelCarSharing.Repositories.Interfaces;

namespace PawelCarSharing.Pages.CarManagment
{
    public class CarEditModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int id { get; set; }
        [BindProperty]
        public Car carToEdit { get; set; }
        private readonly ICarRepository _carRepository;
        private readonly ILogger<LoginModel> _logger;

        public CarEditModel(ILogger<LoginModel> logger, ICarRepository carRepository)
        {
            _logger = logger;
            _carRepository = carRepository;
        }
        public IActionResult OnGet()
        {
            carToEdit = _carRepository.GetOne(id);
            return Page();
        }
        public IActionResult OnPost()
        {
            carToEdit.Id = id;
            _carRepository.Update(carToEdit);
            return RedirectToPage("/CarManagment/CarList");
        }
    }
}
