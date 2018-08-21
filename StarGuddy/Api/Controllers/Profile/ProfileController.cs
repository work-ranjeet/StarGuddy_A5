using Microsoft.AspNetCore.Mvc;
using StarGuddy.Api.Constants;
using StarGuddy.Api.Models.Interface.Profile;
using StarGuddy.Api.Models.Profile;
using StarGuddy.Business.Interface.Account;
using StarGuddy.Business.Interface.Profile;
using StarGuddy.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarGuddy.Api.Controllers.Profile
{
    [Produces("application/json")]
    [Route("api/Profile")]
    public class ProfileController : BaseApiController
    {
        /// <summary>
        /// The account manager
        /// </summary>
        private readonly IAccountManager _accountManager;
        private readonly IProfileManager _profileManager;
        private readonly IUserManager _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileEditController"/> class.
        /// </summary>
        /// <param name="accountManager">The account manager.</param>
        /// <param name="profileManager">The profile manager.</param>
        public ProfileController(IAccountManager accountManager, IProfileManager profileManager, IUserManager userManager)
        {
            _accountManager = accountManager;
            _profileManager = profileManager;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("{profileUrl}")]
        public async Task<IActionResult> GetProfileByUrl(string profileUrl)
        {
            if (string.IsNullOrWhiteSpace(profileUrl))
            {
                return BadRequest(HttpStatusText.InvalidRequest);
            }

            var profileResult = await _profileManager.GetUserProfile(profileUrl);
            if(profileResult == null)
            {
                return NotFound(profileUrl);
            }

            return Ok(profileResult);
        }
    }
}
