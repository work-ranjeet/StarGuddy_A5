using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarGuddy.Api.Models.Account;
using StarGuddy.Business.Interface.Account;
using StarGuddy.Business.Interface.Common;
using StarGuddy.Business.Interface.Profile;
using StarGuddy.Data.Entities;

namespace StarGuddy.Api.Controllers.Profile
{
    [Authorize]
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


        [HttpPost("SavePhysicalApperance")]
        public async Task<string> SavePhysicalApperance(PhysicalAppearance physicalAppearance)
        {
            return await Task.Factory.StartNew(() =>
            {
                this.DecodeJwtToken(this.JwtToken);
                return "test";// await this._profileManager.PerformSave(physicalAppearance);
            });
        }

    }
}