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
        public async Task<IActionResult> Authenticate([FromBody] LoginDto loginCred)
        {
            var token = await _customAuthenticationManager.Authenticate(loginCred.Username, loginCred.Password);

            if (token == null)
                return Unauthorized("Gebruiker is niet bekend");

            return Ok(token);
        }
    }
}