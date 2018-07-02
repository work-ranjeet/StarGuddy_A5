// -------------------------------------------------------------------------------
// <copyright file="UserManager.cs" company="StarGuddy India">
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
    using System.Text;
    using System.Threading.Tasks;
    using StarGuddy.Api.Models.Account;
    using StarGuddy.Api.Models.Interface.Account;
    using StarGuddy.Business.Interface.Account;
    using StarGuddy.Data.Entities;
    using StarGuddy.Data.Entities.Interface;
    using StarGuddy.Repository.Interface;

    /// <summary>
    /// Sign-up Manager Class
    /// </summary>
    /// <seealso cref="ISignupManager" />
    public class UserManager : IUserManager
    {
        /// <summary>
        /// The user repository
        /// </summary>
        private IUserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignupManager"/> class.
        /// </summary>
        /// <param name="signupManager">The user repository.</param>
        public UserManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Adds the new user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// User Object
        /// </returns>
        public async Task<int> CreateAsync(IApplicationUser applicationUser)
        {
            return await Task.Factory.StartNew(() =>
            {
                var user = new User
                {
                    Id = applicationUser.UserId,
                    FirstName = applicationUser.FirstName,
                    LastName = applicationUser.LastName,
                    Gender = applicationUser.Gender,
                    IsCastingProfessional = applicationUser.IsCastingProfessional,
                    Designation = applicationUser.Designation,
                    OrgName = applicationUser.OrgName,
                    OrgWebsite = applicationUser.OrgWebsite,
                    UserName = applicationUser.Email,
                    PasswordHash = applicationUser.Password,
                    SecurityStamp = Convert.ToString(Guid.NewGuid()),
                    IsActive = true,
                    EmailDetail = new UserEmails
                    {
                        Email = applicationUser.Email,
                        IsActive = false,
                        IsDeleted = false,
                        UserId = applicationUser.UserId
                    }
                };

                return this.userRepository.AddNewUser(user);
            });
        }

        /// <summary>
        /// Adds the new user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// User Object
        /// </returns>
        public async Task<int> UpdateUser(IApplicationUser applicationUser)
        {
            return await Task.Factory.StartNew(() =>
            {
                var user = new User
                {
                    Id = applicationUser.UserId,
                    FirstName = applicationUser.FirstName,
                    LastName = applicationUser.LastName,
                    Gender = applicationUser.Gender,
                    IsCastingProfessional = applicationUser.IsCastingProfessional,
                    Designation = applicationUser.Designation,
                    OrgName = applicationUser.OrgName,
                    OrgWebsite = applicationUser.OrgWebsite,
                    UserName = applicationUser.Email,
                    //Email = applicationUser.Email,
                    //NormalizedEmail = applicationUser.Email,
                    //NormalizedUserName = applicationUser.UserName,
                    PasswordHash = applicationUser.Password,
                    SecurityStamp = "39d292dc-8713-4f03-9cfb-90784159f854",
                };

                return this.userRepository.UpdateUser(user);
            });
        }

        /// <summary>
        /// Finds the by identifier asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// IApplication User
        /// </returns>
        public async Task<IApplicationUser> FindByIdAsync(string userId)
        {
            return await Task.Factory.StartNew(() =>
            {
                return new ApplicationUser();
            });
        }

        public void ConfirmEmailAsync(string userId, string code)
        {

        }
    }
}
