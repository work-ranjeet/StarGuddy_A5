using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarGuddy.Api.Common;
using StarGuddy.Api.Models.Account;
using StarGuddy.Api.Models.Interface.Account;
using StarGuddy.Business.Interface.Account;

namespace StarGuddy.Api.Controllers.Account
{   
    [Route("api/Account")]
    [Produces("application/json")]
    public class LoginController : Controller
    {
        private readonly ISignupManager _signUpManager;
        private readonly IJwtPacketManager _jwtPacketManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginController"/> class.
        /// </summary>
        /// <param name="signUpManager">The sign up manager.</param>
        /// <param name="jwtPacketManager">The JWT packet manager.</param>
        public LoginController(ISignupManager signUpManager, IJwtPacketManager jwtPacketManager)
        {
            this._signUpManager = signUpManager;
            this._jwtPacketManager = jwtPacketManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginData loginData)
        {
            if (loginData == null)
            {
                return BadRequest();
            }

            var userResult = await _signUpManager.PasswordSignInAsync(loginData.UserName, loginData.Password, rememberMe: false, lockoutOnFailure: false);
            if (userResult.Id == Guid.Empty)
            {
                return NotFound("Oops! Invalid entry. Please try again.");
            }

            return Ok(this._jwtPacketManager.CreateJwtPacketAsync(userResult));
        }
    }
}
