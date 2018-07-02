using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        [HttpPost][Route("SavePhysicalApperance")]
        public async Task<IActionResult> SavePhysicalApperance([FromBody]PhysicalAppearanceModal physicalAppearance)
        {
            if (physicalAppearance == null || UserContext.UserId == System.Guid.Empty)
            {
                return BadRequest("Invalid/Bad request.");
            }
          
            physicalAppearance.UserId = UserContext.UserId;
            return Ok(await _profileManager.PerformSave(physicalAppearance));
        }


        [HttpGet][Route("PhysicalApperance")]
        public async Task<IActionResult> GetPhysicalApperance()
        {
            if (UserContext.UserId == System.Guid.Empty)
            {
                return BadRequest("Invalid/Bad request.");
            }

            return Ok(await _profileManager.GetPhysicalAppreance(UserContext.UserId));
        }

    }
}