// -------------------------------------------------------------------------------
// <copyright file="JwtPacketManager.cs" company="StarGuddy India">
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
namespace StarGuddy.Api.Common
{
    #region MyRegion
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.IdentityModel.Tokens;
    using Models;
    using StarGuddy.Api.Models.Account;
    using StarGuddy.Api.Models.Interface.Account;
    #endregion

    /// <summary>
    /// JWT Packet Manager
    /// </summary>
    public class JwtPacketManager : IJwtPacketManager
    {
        /// <summary>
        /// Creates the JWT packet asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public async Task<IJwtPacket> CreateJwtPacketAsync(IApplicationUser user)
        {
            return await Task.Factory.StartNew(() =>
            {
                var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(ApiConstants.SecurityKeyPhrase));

                var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

                var claims = new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
                };

                var jwt = new JwtSecurityToken(claims: claims, signingCredentials: signingCredentials);

                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                return new JwtPacket()
                {
                    Id = user.Id.ToString(),
                    Token = encodedJwt,
                    FirstName = user.FirstName,
                    UserName = user.UserName,
                    Email =user.Email
                };
            });
        }
    }

    /// <summary>
    /// JWT Packet Manager
    /// </summary>
    public interface IJwtPacketManager
    {
        /// <summary>
        /// Creates the JWT packet asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        Task<IJwtPacket> CreateJwtPacketAsync(IApplicationUser user);
    }
}
