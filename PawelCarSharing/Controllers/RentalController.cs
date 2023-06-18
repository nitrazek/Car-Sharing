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
    }
}
