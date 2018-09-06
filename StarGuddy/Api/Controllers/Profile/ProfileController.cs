using Microsoft.AspNetCore.Mvc;
using StarGuddy.Api.Constants;
using StarGuddy.Business.Interface.Account;
using StarGuddy.Business.Interface.Profile;
using StarGuddy.Business.Interface.UserJobs;
using System;
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
        private readonly IJobManager _jobManager;


        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileEditController"/> class.
        /// </summary>
        /// <param name="accountManager">The account manager.</param>
        /// <param name="profileManager">The profile manager.</param>
        public ProfileController(IAccountManager accountManager, IProfileManager profileManager, IUserManager userManager, IJobManager jobManager)
        {
            _accountManager = accountManager;
            _profileManager = profileManager;
            _userManager = userManager;
            _jobManager = jobManager;
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
            if (profileResult == null)
            {
                return NotFound(profileUrl);
            }

            return Ok(profileResult);
        }        

        [HttpGet]
        [Route("header/{profileUrl}")]
        public async Task<IActionResult> GetProfileHeader(string profileUrl)
        {
            if(string.IsNullOrWhiteSpace(profileUrl))
            {
                return BadRequest();
            }

            var result = await _profileManager.GetProfileHeaderByProfileUrl(profileUrl);
            if (result.IsNull())
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
