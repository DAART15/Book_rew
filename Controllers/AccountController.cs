using Book_rew.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Book_rew.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IJwtService _jwtService;

        public AccountController(IAccountService accountService, IJwtService jwtService)
        {
            _accountService = accountService;
            _jwtService = jwtService;
        }
        [HttpPost("register")]
        public ActionResult Register(string username, string password, string role)
        {
            _accountService.Register(username, password, role);

            return Ok();
        }
        [HttpGet("login")]
        public ActionResult Login(string username, string password)
        {

            if (_accountService.Login(username, password, out string role))
            {
                return Ok(_jwtService.GenerateToken(username, role));
            }
            return Unauthorized();
        }
    }
}
