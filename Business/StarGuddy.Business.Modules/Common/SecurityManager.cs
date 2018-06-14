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
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Security.Principal;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Cryptography.KeyDerivation;
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
        #region /// Variables
        private const int pbkdf2IterCount = 10000;
        private const int pbkdf2SubkeyLength = 256 / 8; // 256 bits
        private const int saltSize = 128 / 8; // 128 bits 
        #endregion

        #region /// Properties
        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        private IConfiguration _configuration { get; set; }

        private string SeceretKey => this._configuration.GetAppSettingValue(AppSettings.JwtSecret);

        /// <summary>
        /// Gets the encryption byte.
        /// </summary>
        /// <value>
        /// The encryption byte.
        /// </value>
        private byte[] EncryptionByte { get { return new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 }; } }
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
                var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this.SeceretKey));
                var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

                var claims = new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sid, appUser.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, appUser.UserName)
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
        #region /// Public Methods
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

                return HashPasswordInternal(password);
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

                return this.VerifyHashedPasswordInternal(hashedPassword, password);
            });
        }
        #endregion

        #region /// Private methods
        /// <summary>
        /// Hashes the password internal.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>
        /// string values
        /// </returns>
        private string HashPasswordInternal(string password)
        {
            var salt = new byte[saltSize];
            var _rng = RandomNumberGenerator.Create();
            _rng.GetBytes(salt);

            var subkey = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA256, pbkdf2IterCount, pbkdf2SubkeyLength);

            var outputBytes = new byte[13 + salt.Length + subkey.Length];

            // Write format marker.
            outputBytes[0] = 0x01;

            // Write hashing algorithm version.
            this.WriteNetworkByteOrder(outputBytes, 1, (uint)KeyDerivationPrf.HMACSHA256);

            // Write iteration count of the algorithm.
            this.WriteNetworkByteOrder(outputBytes, 5, (uint)pbkdf2IterCount);

            // Write size of the salt.
            this.WriteNetworkByteOrder(outputBytes, 9, (uint)saltSize);

            // Write the salt.
            Buffer.BlockCopy(salt, 0, outputBytes, 13, salt.Length);

            // Write the SUBKEY.
            Buffer.BlockCopy(subkey, 0, outputBytes, 13 + saltSize, subkey.Length);

            return Convert.ToBase64String(outputBytes);
        }

        /// <summary>
        /// Verifies the hashed password internal.
        /// </summary>
        /// <param name="hashedPassword">The hashed password.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// boolean values
        /// </returns>
        private bool VerifyHashedPasswordInternal(string hashedPassword, string password)
        {
            var decodedHashedPassword = Convert.FromBase64String(hashedPassword);

            if (decodedHashedPassword.Length == 0)
            {
                return false;
            }

            try
            {
                // Verify hashing format.
                if (decodedHashedPassword[0] != 0x01)
                {
                    // Unknown format header.
                    return false;
                }

                // Read hashing algorithm version.
                var prf = (KeyDerivationPrf)this.ReadNetworkByteOrder(decodedHashedPassword, 1);

                // Read iteration count of the algorithm.
                var iterCount = (int)this.ReadNetworkByteOrder(decodedHashedPassword, 5);

                // Read size of the salt.
                var saltLength = (int)this.ReadNetworkByteOrder(decodedHashedPassword, 9);

                // Verify the salt size: >= 128 bits.
                if (saltLength < 128 / 8)
                {
                    return false;
                }

                // Read the salt.
                var salt = new byte[saltLength];
                Buffer.BlockCopy(decodedHashedPassword, 13, salt, 0, salt.Length);

                // Verify the SUBKEY length >= 128 bits.
                var subkeyLength = decodedHashedPassword.Length - 13 - salt.Length;
                if (subkeyLength < 128 / 8)
                {
                    return false;
                }

                // Read the SUBKEY.
                var expectedSubkey = new byte[subkeyLength];
                Buffer.BlockCopy(decodedHashedPassword, 13 + salt.Length, expectedSubkey, 0, expectedSubkey.Length);

                // Hash the given password and verify it against the expected SUBKEY.
                var actualSubkey = KeyDerivation.Pbkdf2(password, salt, prf, iterCount, subkeyLength);

                return this.ByteArraysEqual(actualSubkey, expectedSubkey);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Reads the network byte order.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <param name="offset">The offset.</param>
        /// <returns>
        /// unit  values
        /// </returns>
        private uint ReadNetworkByteOrder(byte[] buffer, int offset)
        {
            return ((uint)(buffer[offset + 0]) << 24)
                | ((uint)(buffer[offset + 1]) << 16)
                | ((uint)(buffer[offset + 2]) << 8)
                | ((uint)(buffer[offset + 3]));
        }

        /// <summary>
        /// Writes the network byte order.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="value">The value.</param>
        private void WriteNetworkByteOrder(byte[] buffer, int offset, uint value)
        {
            buffer[offset + 0] = (byte)(value >> 24);
            buffer[offset + 1] = (byte)(value >> 16);
            buffer[offset + 2] = (byte)(value >> 8);
            buffer[offset + 3] = (byte)(value >> 0);
        }

        /// <summary>
        /// Bytes the arrays equal.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>
        /// boolean values
        /// </returns>
        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private bool ByteArraysEqual(byte[] first, byte[] second)
        {
            if (ReferenceEquals(first, second))
            {
                return true;
            }

            if (first == null || second == null || first.Length != second.Length)
            {
                return false;
            }

            var areEqual = true;
            for (var counter = 0; counter < first.Length; counter++)
            {
                areEqual &= (first[counter] == second[counter]);
            }
            return areEqual;
        }
        #endregion
        #endregion

        #region /// Text Encryption
        /// <summary>
        /// Encrypts the text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="securityStamp">The security stamp.</param>
        /// <returns>
        /// string value
        /// </returns>
        public async Task<string> EncryptText(string text, string securityStamp)
        {
            return await Task.Factory.StartNew(() =>
            {
                if (string.IsNullOrEmpty(securityStamp))
                {
                    securityStamp = this._configuration.GetAppSettingValue(AppSettings.EncryptionKey);
                }

                var clearBytes = Encoding.Unicode.GetBytes(text);
                using (var encryptor = Aes.Create())
                {
                    var rfc2898DeriveBytes = new Rfc2898DeriveBytes(securityStamp, this.EncryptionByte);
                    encryptor.Key = rfc2898DeriveBytes.GetBytes(32);
                    encryptor.IV = rfc2898DeriveBytes.GetBytes(16);

                    using (var memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(memoryStream, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }

                        text = Convert.ToBase64String(memoryStream.ToArray());
                    }
                }

                return text;
            });
        }

        /// <summary>
        /// Decrypts the text.
        /// </summary>
        /// <param name="encryptedText">The encrypted text.</param>
        /// <param name="securityStamp">The security stamp.</param>
        /// <returns>
        /// string value
        /// </returns>
        public async Task<string> DecryptText(string encryptedText, string securityStamp)
        {
            return await Task.Factory.StartNew(() =>
            {
                if (string.IsNullOrEmpty(securityStamp))
                {
                    securityStamp = this._configuration.GetAppSettingValue(AppSettings.EncryptionKey);
                }

                encryptedText = encryptedText.Replace(" ", "+");

                var encryptionBytes = Convert.FromBase64String(encryptedText);
                using (Aes encryptor = Aes.Create())
                {
                    var rfc2898DeriveBytes = new Rfc2898DeriveBytes(securityStamp, this.EncryptionByte);
                    encryptor.Key = rfc2898DeriveBytes.GetBytes(32);
                    encryptor.IV = rfc2898DeriveBytes.GetBytes(16);

                    using (var memoryStream = new MemoryStream())
                    {
                        using (var cryptoStream = new CryptoStream(memoryStream, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(encryptionBytes, 0, encryptionBytes.Length);
                            cryptoStream.Close();
                        }

                        encryptedText = Encoding.Unicode.GetString(memoryStream.ToArray());
                    }
                }

                return encryptedText;
            });
        }
        #endregion

        #region /// Object Encryption
        /// <summary>
        /// Encrypts the object.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>string value</returns>
        public string EncryptObject(dynamic value)
        {
            using (var ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, value);
                return Convert.ToBase64String(ms.ToArray());
            }

        }

        /// <summary>
        /// Decrypts the object.
        /// </summary>
        /// <param name="base64">The base64.</param>
        /// <returns>
        /// dynamic object
        /// </returns>
        public dynamic DecryptObject(string base64String)
        {
            var bytes = Convert.FromBase64String(base64String);
            using (var ms = new MemoryStream(bytes, 0, bytes.Length))
            {
                ms.Write(bytes, 0, bytes.Length);
                ms.Position = 0;

                return new BinaryFormatter().Deserialize(ms);
            }
        }
        #endregion
    }
}
