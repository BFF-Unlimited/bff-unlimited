﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bff.WebApi.Managers;
using Bff.WebApi.UserStore;

namespace Bff.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICustomAuthenticationManager customAuthenticationManager;

        public UserController(ICustomAuthenticationManager customAuthenticationManager)
        {
            this.customAuthenticationManager = customAuthenticationManager;
        }


        [AllowAnonymous]
        [HttpPost("token")]
        public IActionResult Authenticate([FromBody] UserDto userCred)
        {
            var token = customAuthenticationManager.Authenticate(userCred.Username, userCred.Password);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }
    }
}