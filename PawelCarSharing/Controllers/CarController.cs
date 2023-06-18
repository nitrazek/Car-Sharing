using Microsoft.AspNetCore.Mvc;
using PawelCarSharing.Data;
using PawelCarSharing.Models;
using PawelCarSharing.Services;
using PawelCarSharing.Repositories;
using PawelCarSharing.Repositories.Interfaces;


namespace PawelCarSharing.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        /*// GET: api/Car
        [HttpGet]
        public IActionResult GetCars()
        {
            var cars = _carRepository.GetCars();
            return Ok(cars);
        }

        // GET: api/Car/{id}
        [HttpGet("{id}")]
        public IActionResult GetCarById(int id)
        {
            var car = _carRepository.GetCarById(id);
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

            // Dodaj samochód do bazy danych
            var createdCar = _carRepository.CreateCar(car);

            // Zwróć odpowiednią odpowiedź HTTP z informacją o utworzonym samochodzie
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
            var updatedCar = _carRepository.UpdateCar(id, car);
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
            var deletedCar = _carRepository.DeleteCar(id);
            if (deletedCar == null)
            {
                return NotFound();
            }
            return Ok(deletedCar);
        }*/
    }
}
