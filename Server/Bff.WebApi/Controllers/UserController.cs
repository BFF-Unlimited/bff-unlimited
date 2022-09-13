using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bff.WebApi.Managers;
using Bff.WebApi.UserStore;

namespace Bff.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICustomAuthenticationManager _customAuthenticationManager;

        public UserController(ICustomAuthenticationManager customAuthenticationManager)
        {
            _customAuthenticationManager = customAuthenticationManager;
        }


        [AllowAnonymous]
        [HttpPost("token")]
        public IActionResult Authenticate([FromBody] UserDto userCred)
        {
            var token = _customAuthenticationManager.Authenticate(userCred.Username, userCred.Password);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }
    }
}