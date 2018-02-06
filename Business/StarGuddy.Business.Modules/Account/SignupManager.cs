// -------------------------------------------------------------------------------
// <copyright file="ISignupManager.cs" company="StarGuddy India">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------
// File Description:
// =================  
// This class file contains properties of customer details.
// -------------------------------------------------------------------------------
// Author: Ranjeet Kumar
// Date Created: 01/01/2018
// -------------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// -------------------------------------------------------------------------------
namespace StarGuddy.Business.Modules.Account
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using StarGuddy.Api.Models.Account;
    using StarGuddy.Api.Models.Interface.Account;
    using StarGuddy.Business.Interface.Account;
    using StarGuddy.Repository.Interfaces;

    /// <summary>
    /// Sign-up Manager Class
    /// </summary>
    /// <seealso cref="ISignupManager" />
    public class SignupManager : ISignupManager
    {
        /// <summary>
        /// The user repository
        /// </summary>
        private IUserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignupManager"/> class.
        /// </summary>
        /// <param name="signupManager">The user repository.</param>
        public SignupManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Passwords the sign in asynchronous.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <param name="rememberMe">if set to <c>true</c> [remember me].</param>
        /// <param name="lockoutOnFailure">if set to <c>true</c> [lockout on failure].</param>
        /// <returns>
        /// Application User
        /// </returns>
        public async Task<IApplicationUser> PasswordSignInAsync(string userName, string password, bool rememberMe = false, bool lockoutOnFailure = false)
        {
            return await Task.Factory.StartNew(() =>
            {
                var result = new ApplicationUser();

                var userResult = this.userRepository.GetVerifiedUser(userName, password).Where(x => x.LockoutEnabled == false);
                if (userResult.Any())
                {
                    var user = userResult.FirstOrDefault();
                    return new ApplicationUser
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Gender = user.Gender,
                        IsCastingProfessional = user.IsCastingProfessional,
                        Designation = user.Designation,
                        OrgName = user.OrgName,
                        OrgWebsite = user.OrgWebsite,
                        UserName = user.UserName
                    };
                }

                return result;
            });
        }
    }
}
