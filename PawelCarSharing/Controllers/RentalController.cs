using Microsoft.AspNetCore.Mvc;
using PawelCarSharing.Models;
using PawelCarSharing.Repositories.Interfaces;
using PawelCarSharing.Services;

namespace PawelCarSharing.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController : ControllerBase
    {
        private readonly IRentalRepository _rentalRepository;

        public RentalController(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        /*[HttpGet]
        public IActionResult GetRentals()
        {
            var rentals = _rentalService.GetRentals();
            return Ok(rentals);
        }

        [HttpGet("{id}")]
        public IActionResult GetRentalById(int id)
        {
            var rental = _rentalService.GetRentalById(id);
            if (rental == null)
            {
                return NotFound();
            }
            return Ok(rental);
        }

        [HttpPost]
        public IActionResult CreateRental(Rental rental)
        {
            var createdRental = _rentalService.CreateRental(rental);
            return CreatedAtAction(nameof(GetRentalById), new { id = createdRental.Id }, createdRental);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRental(int id, Rental rental)
        {
            var updatedRental = _rentalService.UpdateRental(id, rental);
            if (updatedRental == null)
            {
                return NotFound();
            }
            return Ok(updatedRental);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRental(int id)
        {
            var deletedRental = _rentalService.DeleteRental(id);
            if (deletedRental == null)
            {
                return NotFound();
            }
            return Ok(deletedRental);
        }*/
    }
}
