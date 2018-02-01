using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarGuddy.Business.Interface.Account;

namespace StarGuddy.Api.Controllers.Account
{
    [Produces("application/json")]
    [Route("api/Account/Manage")]
    public class ManageAccController : Controller
    {
        /// <summary>
        /// The account manager
        /// </summary>
        private readonly IAccountManager _accountManager;

        /// <summary>
        /// The password manager
        /// </summary>
        private readonly IPasswordManager _passwordManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManageAccController"/> class.
        /// </summary>
        /// <param name="accountManager">The account manager.</param>
        /// <param name="passwordManager">The password manager.</param>
        public ManageAccController(IAccountManager accountManager, IPasswordManager passwordManager)
        {
            this._accountManager = accountManager;
            this._passwordManager = passwordManager;
        }

    }
}