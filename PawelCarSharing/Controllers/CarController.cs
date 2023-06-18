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
    }
}
