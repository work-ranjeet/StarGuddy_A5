using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarGuddy.Api.Models.Profile;
using StarGuddy.Business.Interface.Account;
using StarGuddy.Business.Interface.Profile;
using StarGuddy.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace StarGuddy.Api.Controllers.Profile
{
    [Produces("application/json")]
    [Route("api/Profile/Operations")]
    public class ProfileEditController : BaseApiController
    {
        /// <summary>
        /// The account manager
        /// </summary>
        private readonly IAccountManager accountManager;
        private readonly IProfileManager profileManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileEditController"/> class.
        /// </summary>
        /// <param name="accountManager">The account manager.</param>
        /// <param name="profileManager">The profile manager.</param>
        public ProfileEditController(IAccountManager accountManager, IProfileManager profileManager, IHttpContextAccessor httpContextAccessor)
        {
            this.accountManager = accountManager;
            this.profileManager = profileManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        #region Physical appearance
        [HttpPost]
        [Route("SavePhysicalApperance")]
        public async Task<IActionResult> SavePhysicalApperance([FromBody]PhysicalAppearanceModal physicalAppearance)
        {
            if (UserContext.Current.UserId == Guid.Empty)
            {
                return Unauthorized();
            }

            if (physicalAppearance == null)
            {
                return BadRequest("Invalid/Bad request.");
            }

            physicalAppearance.UserId = UserContext.Current.UserId;
            return Ok(await profileManager.PerformSave(physicalAppearance));
        }


        [HttpGet]
        [Route("PhysicalApperance")]
        public async Task<IActionResult> GetPhysicalApperance()
        {
            if (UserContext.Current.UserId == Guid.Empty)
            {
                return Unauthorized();
            }

            var result = await profileManager.GetPhysicalAppreance(UserContext.Current.UserId);

            if (result.IsNull())
            {
                return NotFound();
            }

            return Ok(result);

        }
        #endregion

        #region Credits
        [HttpGet]
        [Route("Credit")]
        public async Task<IActionResult> GetUserCredits()
        {
            if (UserContext.Current.UserId == Guid.Empty)
            {
                return Unauthorized();
            }

            var creditResult = await profileManager.GetUserCredits(UserContext.Current.UserId);

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
            if (credits == null || UserContext.Current.UserId == System.Guid.Empty)
            {
                return BadRequest("Invalid/Bad request.");
            }

            var isSuccess = await profileManager.SaveUserCredits(UserContext.Current.UserId, credits);
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
            if (UserContext.Current.UserId == System.Guid.Empty || Id == Guid.Empty)
            {
                return BadRequest("Invalid/Bad request.");
            }

            var isDeleted = await profileManager.DeleteUserCredits(Id);

            if (isDeleted)
            {
                return Ok(isDeleted);
            }

            return StatusCode(Convert.ToInt32(HttpStatusCode.NotModified), this);
        }
        #endregion

        #region Dancing
        [HttpGet]
        [Route("Dancing")]
        public async Task<IActionResult> GetUserDancing()
        {
            if (UserContext.Current.UserId == Guid.Empty)
            {
                return Unauthorized();
            }

            var dancingResult = await profileManager.GetUserDancingAsync(UserContext.Current.UserId);

            if (dancingResult.IsNull())
            {
                return NotFound(dancingResult); 
            }

            return Ok(dancingResult);
        }

        [HttpPost]
        [Route("Dancing")]
        public async Task<IActionResult> SaveUserDancing([FromBody]DancingModel dancingModel)
        {
            if (UserContext.Current.UserId == Guid.Empty)
            {
                return Unauthorized();
            }

            if (dancingModel == null)
            {
                return BadRequest("Invalid/Bad request.");
            }

            var isSuccess = await profileManager.SaveUserDancingAsync(dancingModel);
            if (isSuccess)
            {
                return Ok(isSuccess);
            }

            return StatusCode(HttpStatusCode.NotModified.GetHashCode(), this);
        }
        #endregion
    }
}