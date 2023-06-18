using Microsoft.AspNetCore.Mvc;
using PawelCarSharing.Models;
using PawelCarSharing.Services;
using PawelCarSharing.Repositories;
using PawelCarSharing.Repositories.Interfaces;

namespace PawelCarSharing.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountService)
        {
            _accountRepository = accountService;
        }

        /*[HttpGet]
        public IActionResult GetUsers()
        {

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User user)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            return Ok();
        }*/
    }
}
