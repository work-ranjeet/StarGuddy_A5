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
    using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IUserSettingsRepository _userSettingsRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignupManager"/> class.
        /// </summary>
        /// <param name="signupManager">The user repository.</param>
        public UserManager(IUserRepository userRepository, IUserSettingsRepository userSettingsRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userSettingsRepository = userSettingsRepository;
        }

        /// <summary>
        /// Adds the new user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// User Object
        /// </returns>
        public async Task<bool> CreateAsync(IApplicationUser applicationUser)
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

                return _userRepository.AddNewUser(user);
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

                return this._userRepository.UpdateUser(user);
            });
        }

        public async Task<IApplicationUser> FindByUserNameAsync(string userName)
        {
            return await Task.Factory.StartNew(() =>
            {
                var user = _userRepository.FindByUserName(userName);
                if(user.IsNull())
                {
                    return null;
                }

                return new ApplicationUser
                {
                    UserId = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Gender = user.Gender,
                    IsCastingProfessional = user.IsCastingProfessional,
                    Designation = user.Designation,
                    OrgName = user.OrgName,
                    OrgWebsite = user.OrgWebsite,
                    UserName = user.UserName,
                    Email = user.EmailDetail.IsNull() ? string.Empty : user.EmailDetail.Email,
                    SecurityStamp = user.SecurityStamp
                };
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
