using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bff.WebApi.Managers;
using Bff.WebApi.UserStore;

namespace Bff.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ICustomAuthenticationManager _customAuthenticationManager;

        public LoginController(ICustomAuthenticationManager customAuthenticationManager)
        {
            _customAuthenticationManager = customAuthenticationManager;
        }


        [AllowAnonymous]
        [HttpPost("token")]
        public IActionResult Authenticate([FromBody] LoginDto loginCred)
        {
            var token = _customAuthenticationManager.Authenticate(loginCred.Username, loginCred.Password);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }
    }
}