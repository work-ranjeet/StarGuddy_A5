// -------------------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="StarGuddy India">
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
// ReSharper disable once CheckNamespace
namespace StarGuddy.Repository.Operation
{
    using System;
    #region Imports
    using System.Collections.Generic;
    using System.Data;
    using Dapper;
    using StarGuddy.Data.Entities;
    using StarGuddy.Data.Entities.Interface;
    using StarGuddy.Repository.Base;
    using StarGuddy.Repository.Configuration;
    using StarGuddy.Repository.Interface;
    using StarGuddy.Repository.Opertions.Constants;
    #endregion

    /// <summary>
    /// User Repository
    /// </summary>
    /// <seealso cref="StarGuddy.Repository.Base.RepositoryAbstract{User}" />
    /// <seealso cref="StarGuddy.Repository.Base.RepositoryAbstract{User}" />
    /// <seealso cref="StarGuddy.Repository.Interfaces.IUserRepository" />
    public class UserRepository : RepositoryAbstract<User>, IUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository" /> class.
        /// </summary>
        /// <param name="configurationSingleton">The configuration singleton.</param>
        /// <inheritdoc />
        public UserRepository(IConfigurationSingleton configurationSingleton) : base(configurationSingleton, SqlTable.Users)
        {
        }

        #region /// Select
        /// <summary>
        /// Finds the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Application User
        /// </returns>
        public IUser FindById(string id)
        {
            return this.FindSingle("SELECT * FROM Users WHERE Id=@Id", new { Id = id });
        }

        /// <summary>
        /// Finds the by user name.
        /// </summary>
        /// <param name="userName">user name</param>
        /// <returns>
        /// User data object
        /// </returns>
        public IUser FindByUserName(string userName)
        {
            return this.FindSingle("SELECT * FROM Users WHERE UserName=@UserName", new { UserName = userName });
        }

        /// <summary>
        /// Finds the by email identifier.
        /// </summary>
        /// <param name="emaiId">The email identifier.</param>
        /// <returns>
        /// Application User
        /// </returns>
        public IUser FindByEmailId(string emaiId)
        {
            return this.FindSingle("SELECT * FROM Users WHERE Email=@EmailId", new { EmailId = emaiId });
        }

        /// <summary>
        /// Gets the verified user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// Application User
        /// </returns>
        public IEnumerable<IUser> GetVerifiedUser(string userName, string password)
        {
            var parameter = new
            {
                UserName = userName,
                Password = password
            };

            return this.GetProcedureData("GetVarifiedUser", parameter);
        }
        #endregion

        #region /// Insert
        /// <summary>
        /// Adds the new user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// Application User
        /// </returns>
        public int AddNewUser(IUser user)
        {
            using (var conn = this.GetOpenConnectionAsync)
            {
                var parameter = new
                {
                    AccessFailedCount = 0,
                    ConcurrencyStamp = Guid.NewGuid(),
                    LockoutEnd = DateTime.UtcNow.AddSeconds(-1),
                    IsTwoFactorEnabled = false,
                    user.EmailDetail.Email,
                    user.FirstName,
                    user.Gender,
                    user.IsCastingProfessional,
                    user.LastName,
                    user.LockoutEnabled,
                    user.Designation,
                    user.OrgName,
                    user.OrgWebsite,
                    user.PasswordHash,
                    user.SecurityStamp,
                    user.UserName
                };

                return conn.Execute(SpNames.User.AddNewUser, param: parameter, commandType: CommandType.StoredProcedure);
            }
        }

        #endregion

        #region /// Update
        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// Application User
        /// </returns>
        public int UpdateUser(IUser user)
        {
            using (var conn = this.GetOpenConnectionAsync)
            {
                var parameter = user;
                parameter.AccessFailedCount = 0;
                parameter.ConcurrencyStamp = "b8c6e4a2-fb40-4706-b608-f05a4a6ff708";
                parameter.LockoutEnd = DateTime.UtcNow;
                parameter.IsTwoFactorEnabled = false;

                //var parameter = new
                //{
                //    AccessFailedCount = 0,
                //    ConcurrencyStamp = "b8c6e4a2-fb40-4706-b608-f05a4a6ff708",
                //    //Email = user.Email,
                //    //EmailConfirmed = user.EmailConfirmed,
                //    //FirstName = user.FirstName,
                //    //Gender = user.Gender,
                //    //IsCastingProfessional = user.IsCastingProfessional,
                //    //LastName = user.LastName,
                //    //LockoutEnabled = user.LockoutEnabled,
                //    LockoutEnd = DateTime.UtcNow,
                //    //NormalizedEmail = user.NormalizedEmail,
                //    //NormalizedUserName = user.NormalizedUserName,
                //    //Designation = user.Designation,
                //    //OrgName = user.OrgName,
                //    //OrgWebsite = user.OrgWebsite,
                //    //PasswordHash = user.PasswordHash,
                //    //PhoneNumber = user.PhoneNumber,
                //    //PhoneNumberConfirmed = false,
                //    //SecurityStamp = user.SecurityStamp,
                //    TwoFactorEnabled = false,
                //    //UserName = user.UserName
                //};

                return conn.Execute(SpNames.User.UpdateUser, param: parameter, commandType: CommandType.StoredProcedure);
            }

        }

        /// <summary>
        /// Updates the password.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public int UpdatePassword(string userName, string password)
        {
            using (var conn = this.GetOpenConnectionAsync)
            {
                var query = string.Format("update Users set PasswordHash='{0}' where UserName = '{1}'", password, userName);
                return conn.Execute(query, commandType: CommandType.Text);
            }
        }
        #endregion
    }
}
