using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StarGuddy.Api.Models.Profile;
using StarGuddy.Business.Interface.Account;
using StarGuddy.Business.Interface.Profile;
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
        private readonly IAccountManager _accountManager;

        private readonly IProfileManager _profileManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileEditController"/> class.
        /// </summary>
        /// <param name="accountManager">The account manager.</param>
        /// <param name="profileManager">The profile manager.</param>
        public ProfileEditController(IAccountManager accountManager, IProfileManager profileManager)
        {
            this._accountManager = accountManager;
            this._profileManager = profileManager;
        }

        [HttpPost][Route("SavePhysicalApperance")]
        public async Task<IActionResult> SavePhysicalApperance([FromBody]PhysicalAppearanceModal physicalAppearance)
        {
            if (physicalAppearance == null)
            {
                return BadRequest("Invalid request.");
            }

            base.DecodeJwtToken();
            physicalAppearance.UserId = UserContext.UserId;

            return Ok(await _profileManager.PerformSave(physicalAppearance));
        }


        [HttpGet][Route("PhysicalApperance")]
        public async Task<IActionResult> GetPhysicalApperance()
        {  
            base.DecodeJwtToken();
            if (UserContext.UserId == System.Guid.Empty)
            {
                return BadRequest("Invalid request.");
            }

            return Ok(await _profileManager.GetPhysicalAppreance(UserContext.UserId));
        }

    }
}