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
namespace StarGuddy.Repository.Operations
{
    #region Imports
    using System.Collections.Generic;
    using StarGuddy.Data.Entities.Interface;
    using StarGuddy.Repository.Base;
    using StarGuddy.Repository.Configuration;
    using StarGuddy.Repository.Interfaces;
    #endregion

    /// <summary>
    /// User Repository
    /// </summary>
    /// <seealso cref="StarGuddy.Repository.Base.RepositoryAbstract{User}" />
    /// <seealso cref="StarGuddy.Repository.Base.RepositoryAbstract{User}" />
    /// <seealso cref="StarGuddy.Repository.Interfaces.IUserRepository" />
    public class UserRepository : RepositoryAbstract<IUser>, IUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository" /> class.
        /// </summary>
        /// <param name="configurationSingleton">The configuration singleton.</param>
        /// <inheritdoc />
        public UserRepository(IConfigurationSingleton configurationSingleton) : base(configurationSingleton, "Users")
        {
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
            return this.FindSingle("SELECT * FROM Users WHERE UserName=@Username", new { Username = userName });
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
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// Application User
        /// </returns>
        public IEnumerable<IUser> GetVerifiedUser(string email, string password)
        {
            using (var conn = this.GetOpenConnectionAsync)
            {
                var parameter = new
                {
                    Email = email,
                    Password = password
                };

                return this.GetProcedureData("GetVarifiedUser", parameter);
            }
        }
    }
}
