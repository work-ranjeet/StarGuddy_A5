// -------------------------------------------------------------------------------
// <copyright file="ImageManager.cs" company="StarGuddy India">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------
namespace StarGuddy.Business.Interface.Common
{
    using StarGuddy.Api.Models.Interface.Account;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public interface ISecurityManager
    {
        /// <summary>
        /// Encrypts the JWT security token asynchronous.
        /// </summary>
        /// <param name="appUser">The application user.</param>
        /// <returns>
        /// JWT Packet
        /// </returns>
        Task<string> GetJwtSecurityTokenAsync(IApplicationUser appUser);

        /// <summary>
        /// Validates the JWT security token asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="securityStamp">The security stamp.</param>
        /// <returns>string value</returns>
        Task<bool> ValidateJwtSecurityTokenAsync(string userId, string securityStamp);

        /// <summary>
        /// Hashes the password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>
        /// String Value
        /// </returns>
        Task<string> GetHashPassword(string password);

        /// <summary>
        /// Verifies the hashed password.
        /// </summary>
        /// <param name="hashedPassword">The hashed password.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// String Value
        /// </returns>
        Task<bool> VerifyHashedPassword(string hashedPassword, string password);

      
    }
}
