using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PawelCarSharing.Models;
using PawelCarSharing.Repositories;
using PawelCarSharing.Repositories.Interfaces;

namespace PawelCarSharing.Pages.RentalManagment
{
    public class RentalEditModel : PageModel
    {
        public List<SelectListItem> cars { get; set; }
        [BindProperty(SupportsGet = true)]
        public int id { get; set; }
        [BindProperty]
        public Rental rentalToEdit { get; set; }
        private readonly IRentalRepository _rentalRepository;
        private readonly ILogger<LoginModel> _logger;
        private readonly ICarRepository _carRepository;

        public RentalEditModel(ILogger<LoginModel> logger, IRentalRepository rentalRepository, ICarRepository carRepository)
        {
            _logger = logger;
            _rentalRepository = rentalRepository;
            _carRepository = carRepository;
        }
        public IActionResult OnGet()
        {
            cars = _carRepository.GetAll().Select(car => new SelectListItem { Value = car.Id.ToString(), Text = $"{car.Brand} {car.Model}" }).ToList();
            rentalToEdit = _rentalRepository.GetOne(id);
            return Page();
        }
        public IActionResult OnPost()
        {
            rentalToEdit.Id = id;
            _rentalRepository.Update(rentalToEdit);
            return RedirectToPage("/RentalManagment/RentalList");
        }
    }
}
