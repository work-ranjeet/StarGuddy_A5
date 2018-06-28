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
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Security.Principal;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Cryptography.KeyDerivation;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using StarGuddy.Api.Models.Interface.Account;
    using StarGuddy.Business.Interface.Common;
    using StarGuddy.Core.Constants;

    /// <summary>
    /// Security Manager Class
    /// </summary>
    /// <seealso cref="StarGuddy.Business.Interface.Common.ISecurityManager" />
    public class SecurityManager : ISecurityManager
    {   
        #region /// Properties
        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        private IConfiguration _configuration { get; set; }

        private string SeceretKey => this._configuration.GetAppSettingValue(AppSettings.JwtSecret);

       
        #endregion

        #region /// Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityManager"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public SecurityManager(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        #endregion

        #region /// JWT Tokens
        /// <summary>
        /// Encrypts the JWT security token asynchronous.
        /// </summary>
        /// <param name="appUser">The application user.</param>
        /// <returns>
        /// JWT Packet
        /// </returns>
        public async Task<string> GetJwtSecurityTokenAsync(IApplicationUser appUser)
        {
            return await Task.Factory.StartNew(() =>
            {
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.SeceretKey));
                var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha256Digest);

                var claims = new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sid, appUser.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, appUser.UserName)
                    //new Claim(ClaimTypes.UserData, EncryptObject(appUser))
                };
                
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    SigningCredentials = signingCredentials,
                    Issuer = _configuration.GetAppSettingValue(AppSettings.JwtIssuer),
                    Audience = _configuration.GetAppSettingValue(AppSettings.JwtAudience),
                    Expires = DateTime.UtcNow.AddMinutes(30)
                };

                var jwtTokenHandler = new JwtSecurityTokenHandler();

                if (jwtTokenHandler.CanWriteToken)
                {
                    var token = jwtTokenHandler.CreateToken(tokenDescriptor);
                    return jwtTokenHandler.WriteToken(token);
                }

                return string.Empty;
            });
        }

        /// <summary>
        /// Validates the JWT security token asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="securityStamp">The security stamp.</param>
        /// <returns>string value</returns>
        public async Task<bool> ValidateJwtSecurityTokenAsync(string jwtToken, string securityStamp)
        {
            return await Task.Factory.StartNew(() =>
            {
                var simplePrinciple = this.GetPrincipal(jwtToken);
                var identity = simplePrinciple.Identity as ClaimsIdentity;
                if (identity == null)
                    return false;

                if (!identity.IsAuthenticated)
                    return false;

                var userIdClaim = identity.FindFirst(ClaimTypes.Sid);


                if (userIdClaim.IsNull())
                    return false;

                return true;
            });
        }

        //private Task<IPrincipal> AuthenticateJwtToken(string token)
        //{
        //    if (await ValidateJwtSecurityTokenAsync(token, out Guid userId))
        //    {

        //        var claims = new List<Claim> { new Claim(ClaimTypes.Sid, userId.ToString()) };
        //        var identity = new ClaimsIdentity(claims, "Jwt");
        //        IPrincipal user = new ClaimsPrincipal(identity);
        //        return Task.FromResult(user);
        //    }
        //    return Task.FromResult<IPrincipal>(null);
        //}

        private ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
                if (jwtToken == null) return null;
                var symmetricKey = Convert.FromBase64String(this.SeceretKey);
                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                };

                var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken securityToken);

                return principal;
            }
            catch (Exception)
            {
                //should write log  
                return null;
            }
        }
        #endregion

        #region /// Password Hashing
        /// <summary>
        /// Hashes the password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>
        /// String Value
        /// </returns>
        public async Task<string> GetHashPassword(string password)
        {
            return await Task.Factory.StartNew(() =>
            {
                if (password == null)
                {
                    throw new ArgumentNullException(nameof(password));
                }

                return CryptoGraphy.HashPasswordInternal(password);
            });
        }

        /// <summary>
        /// Verifies the hashed password.
        /// </summary>
        /// <param name="hashedPassword">The hashed password.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// String Value
        /// </returns>
        public async Task<bool> VerifyHashedPassword(string hashedPassword, string password)
        {
            return await Task.Factory.StartNew(() =>
            {
                if (hashedPassword == null)
                {
                    throw new ArgumentNullException(nameof(hashedPassword));
                }
                if (password == null)
                {
                    throw new ArgumentNullException(nameof(password));
                }

                return CryptoGraphy.VerifyHashedPasswordInternal(hashedPassword, password);
            });
        }
        #endregion
    }
}
