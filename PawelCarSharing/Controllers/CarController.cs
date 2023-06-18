using Microsoft.AspNetCore.Mvc;
using PawelCarSharing.Models;
using PawelCarSharing.Services;

namespace PawelCarSharing.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly CarService _carService;

        public CarController(CarService carService)
        {
            _carService = carService;
        }

        // GET: api/Car
        [HttpGet]
        public IActionResult GetCars()
        {
            var cars = _carService.GetCars();
            return Ok(cars);
        }

        // GET: api/Car/{id}
        [HttpGet("{id}")]
        public IActionResult GetCarById(int id)
        {
            var car = _carService.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        // POST: api/Car
        [HttpPost]
        public IActionResult CreateCar([FromBody] Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdCar = _carService.CreateCar(car);
            return CreatedAtAction(nameof(GetCarById), new { id = createdCar.Id }, createdCar);
        }

        // PUT: api/Car/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCar(int id, [FromBody] Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedCar = _carService.UpdateCar(id, car);
            if (updatedCar == null)
            {
                return NotFound();
            }
            return Ok(updatedCar);
        }

        // DELETE: api/Car/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var deletedCar = _carService.DeleteCar(id);
            if (deletedCar == null)
            {
                return NotFound();
            }
            return Ok(deletedCar);
        }
    }
}