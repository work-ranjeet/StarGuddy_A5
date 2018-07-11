using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarGuddy.Api.Models.Profile;
using StarGuddy.Business.Interface.Account;
using StarGuddy.Business.Interface.Profile;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Net;
using System.Collections.Generic;

namespace StarGuddy.Api.Controllers.Profile
{
    [Produces("application/json")]
    [Route("api/Profile/Operations")]
    public class ProfileEditController : BaseApiController
    {
        /// <summary>
        /// The account manager
        /// </summary>
        private readonly IAccountManager _accountManager;

        private readonly IProfileManager _profileManager;

        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileEditController"/> class.
        /// </summary>
        /// <param name="accountManager">The account manager.</param>
        /// <param name="profileManager">The profile manager.</param>
        public ProfileEditController(IAccountManager accountManager, IProfileManager profileManager, IHttpContextAccessor httpContextAccessor)
        {
            this._accountManager = accountManager;
            this._profileManager = profileManager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        [Route("SavePhysicalApperance")]
        public async Task<IActionResult> SavePhysicalApperance([FromBody]PhysicalAppearanceModal physicalAppearance)
        {
            if (physicalAppearance == null || UserContext.UserId == System.Guid.Empty)
            {
                return BadRequest("Invalid/Bad request.");
            }

            physicalAppearance.UserId = UserContext.UserId;
            return Ok(await _profileManager.PerformSave(physicalAppearance));
        }


        [HttpGet]
        [Route("PhysicalApperance")]
        public async Task<IActionResult> GetPhysicalApperance()
        {
            if (UserContext.UserId == System.Guid.Empty)
            {
                return BadRequest("Invalid/Bad request.");
            }

            var result = await _profileManager.GetPhysicalAppreance(UserContext.UserId);

            if (result.IsNull())
            {
                return NotFound();
            }

            return Ok(result);
          
        }


        [HttpGet]
        [Route("Credit")]
        public async Task<IActionResult> GetUserCredits()
        {
            if (UserContext.UserId == System.Guid.Empty)
            {
                return BadRequest("Invalid/Bad request.");
            }

            var creditResult = await _profileManager.GetUserCredits(UserContext.UserId);

            if (!creditResult.IsNull() && creditResult.Any())
            {
                return Ok(creditResult);
            }

            if (!creditResult.IsNull() && !creditResult.Any())
            {
                return NoContent();
            }

            return NotFound(creditResult);
        }

        [HttpPost]
        [Route("Credit")]
        public async Task<IActionResult> SaveUserCredits([FromBody]List<UserCreditModel> credits)
        {
            if (credits == null || UserContext.UserId == System.Guid.Empty)
            {
                return BadRequest("Invalid/Bad request.");
            }

            var isSuccess = await _profileManager.SaveUserCredits(UserContext.UserId, credits);
            if (isSuccess)
            {
                return Ok(isSuccess);
            }

            return StatusCode(Convert.ToInt32(HttpStatusCode.NotModified), this);
        }

        [HttpDelete]
        [Route("Credit")]
        public async Task<IActionResult> DeleteUserCredits(Guid Id)
        {
            if (UserContext.UserId == System.Guid.Empty || Id == Guid.Empty)
            {
                return BadRequest("Invalid/Bad request.");
            }

            var isDeleted = await _profileManager.DeleteUserCredits(Id);

            if (isDeleted)
            {
                return Ok(isDeleted);
            }

            return StatusCode(Convert.ToInt32(HttpStatusCode.NotModified), this);
        }

    }
}