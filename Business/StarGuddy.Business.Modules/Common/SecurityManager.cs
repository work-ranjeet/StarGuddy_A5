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
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using StarGuddy.Business.Interface.Common;
    using StarGuddy.Core.Constants;

    /// <summary>
    /// Security Manager Class
    /// </summary>
    /// <seealso cref="StarGuddy.Business.Interface.Common.ISecurityManager" />
    public class SecurityManager : ISecurityManager
    {
        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        private IConfiguration _configuration { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityManager"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public SecurityManager(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        /// <summary>
        /// Encrypts the JWT security token asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// JWT Packet
        /// </returns>
        public async Task<string> GetJwtSecurityTokenAsync(string userId)
        {
            return await Task.Factory.StartNew(() =>
            {
                var seceretKey = this._configuration.GetAppSettingValue(AppSettings.JwtSecret);
                var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(seceretKey));
                var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

                var claims = new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, userId)
                };

                var jwt = new JwtSecurityToken(
                        issuer: this._configuration.GetAppSettingValue(AppSettings.JwtIssuer),
                        audience: this._configuration.GetAppSettingValue(AppSettings.JwtAudience),
                        claims: claims,
                        expires: DateTime.UtcNow.AddHours(1),
                        signingCredentials: signingCredentials
                    );

                return new JwtSecurityTokenHandler().WriteToken(jwt);
            });
        }

        public async Task<string> DecryptJwtSecurityTokenAsync(string userId, string securityStamp)
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
