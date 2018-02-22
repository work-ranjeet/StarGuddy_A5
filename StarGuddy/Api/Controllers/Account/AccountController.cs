using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StarGuddy.Api.Common;
using StarGuddy.Api.Security.Jwt;
using StarGuddy.Business.Interface.Account;

namespace StarGuddy.Api.Controllers.Account
{
    /// <summary>
    /// Account Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/Account")]
    [Produces("application/json")]
    public class AccountController : Controller
    {
        private readonly IUserManager _userManager;
        private readonly IJwtPacketManager _jwtPacketManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="signUpManager">The sign up manager.</param>
        /// <param name="jwtPacketManager">The JWT packet manager.</param>
        public AccountController(IUserManager userManager, IJwtPacketManager jwtPacketManager)
        {
            this._userManager = userManager;
            this._jwtPacketManager = jwtPacketManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return BadRequest();
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("Oops! No User preset with this Id. Please try again.");
            }
           // var result = await _userManager.ConfirmEmailAsync(user, code);
            return Ok();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmailSent()
        {
            return await Task.Run(() => View());
        }
    }
}