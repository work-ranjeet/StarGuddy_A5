// -------------------------------------------------------------------------------
// <copyright file="SecurityManager.cs" company="StarGuddy India">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------
namespace StarGuddy.Business.Modules.Common
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.IdentityModel.Tokens;
    using StarGuddy.Business.Interface.Common;

    /// <summary>
    /// Security Manager Class
    /// </summary>
    /// <seealso cref="StarGuddy.Business.Interface.Common.ISecurityManager" />
    public class SecurityManager : ISecurityManager
    {
        /// <summary>
        /// Creates the JWT packet asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="securityStamp">The security stamp.</param>
        /// <returns>
        /// JWT Packet
        /// </returns>
        public async Task<string> CreateJwtSecurityTokenAsync(string userId, string securityStamp)
        {
            return await Task.Factory.StartNew(() =>
            {
                var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(securityStamp));

                var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

                var claims = new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, userId)
                };

                var jwt = new JwtSecurityToken(claims: claims, signingCredentials: signingCredentials);

                return new JwtSecurityTokenHandler().WriteToken(jwt);
            });
        }

    }
}
