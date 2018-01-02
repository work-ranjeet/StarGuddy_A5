using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarGuddy.Api.Common;
using StarGuddy.Api.Models.Interface.Account;
using StarGuddy.Business.Interface.Account;

namespace StarGuddy.Api.Controllers.Account
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class LoginController : Controller
    {
        private readonly IAccountManager _accountManager;
        private readonly IJwtPacketManager _jwtPacketManager;
        public LoginController(IAccountManager accountManager, IJwtPacketManager jwtPacketManager)
        {
            this._accountManager = accountManager;
            this._jwtPacketManager = jwtPacketManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] ILoginData loginData)
        {
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            var userResult = await _accountManager.PasswordSignInAsync(loginData.Email, loginData.Password, rememberMe: false, lockoutOnFailure: false);

            if (userResult.Id == Guid.Empty)
            {
                return NotFound("email or password incorrect");
            }

            return Ok(this._jwtPacketManager.CreateJwtPacketAsync(userResult));
        }
    }
}
