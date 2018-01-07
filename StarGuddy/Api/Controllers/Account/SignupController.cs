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
    public class SignupController : Controller
    {
        private readonly IAccountManager _accountManager;
        private readonly ISignupManager _signUpManager;
        private readonly IJwtPacketManager _jwtPacketManager;

        public SignupController(IAccountManager accountManager, ISignupManager signupManager, IJwtPacketManager jwtPacketManager)
        {
            this._accountManager = accountManager;
            this._signUpManager = signupManager;
            this._jwtPacketManager = jwtPacketManager;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody]ApplicationUser applicationUser)
        {
            var result = await this._signUpManager.CreateAsync(applicationUser);
            if (result > 0)
            {
                var userResult = await this._accountManager.PasswordSignInAsync(applicationUser.Email, applicationUser.Password, rememberMe: false, lockoutOnFailure: false);

                if (userResult.Id == Guid.Empty)
                {
                    return StatusCode(StatusCodes.Status204NoContent, NotFound("email or password incorrect")); 
                }

                return Ok(this._jwtPacketManager.CreateJwtPacketAsync(userResult));
            }

            return StatusCode(StatusCodes.Status204NoContent, NotFound("email or password incorrect"));
        }
    }
}
