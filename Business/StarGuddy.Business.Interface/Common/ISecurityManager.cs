// -------------------------------------------------------------------------------
// <copyright file="ImageManager.cs" company="StarGuddy India">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------
namespace StarGuddy.Business.Interface.Common
{
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
        /// Creates the JWT packet asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="securityStamp">The security stamp.</param>
        /// <returns>
        /// JWT Packet
        /// </returns>
        Task<string> CreateJwtSecurityTokenAsync(string userId, string securityStamp);
    }
}
