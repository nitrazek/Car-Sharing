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

        
    }
}
