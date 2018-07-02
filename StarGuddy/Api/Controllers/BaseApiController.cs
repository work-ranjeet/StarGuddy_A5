using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StarGuddy.Api.Models.Account;
using StarGuddy.Api.Models.Interface.Account;
using StarGuddy.Business.Interface.Common;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Claims;
using System.Text;
//using System.Net.Http.Headers;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace StarGuddy.Api.Controllers
{
    public abstract class BaseApiController : Controller
    {
        #region /// properties
        public IUserContext UserContext { get; private set; }

        private Exception Exception { get; set; } = null;

        private string JwtToken => HttpContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.ToString();
        #endregion

        #region /// Public methods
        public void DecodeJwtToken()
        {
            if (string.IsNullOrWhiteSpace(JwtToken))
            {
                Exception = new Exception("Invalid Token.");
            }

            var innerJwtTokenArr = JwtToken.Split(' ');
            if (innerJwtTokenArr.Length != 2 || !innerJwtTokenArr[0].ToLowerInvariant().Equals("bearer"))
            {
                Exception = new Exception("Token is missing.");
            }

            if (Exception != null)
            {
                throw Exception;
            }

            SetUserContext(innerJwtTokenArr[1]);

        }
        #endregion

        #region /// Private methods
        private void SetUserContext(string jwtInput)
        {
            var jwtHandler = new JwtSecurityTokenHandler();

            var readableToken = jwtHandler.CanReadToken(jwtInput);

            if (readableToken)
            {
                var userPayloadToken = jwtHandler.ReadJwtToken(jwtInput);
                string userId = ((userPayloadToken)).Claims.FirstOrDefault(m => m.Type == JwtRegisteredClaimNames.Sid).Value;
                string email = ((userPayloadToken)).Claims.FirstOrDefault(m => m.Type == JwtRegisteredClaimNames.Email).Value;
                //string userData = ((userPayloadToken)).Claims.FirstOrDefault(m => m.Type == ClaimTypes.UserData).Value;

                UserContext = new UserContext
                {
                    UserId = Guid.Parse(userId),
                    UserName = email,
                    Email = email,
                    FirstName = "",
                    LastName = ""
                };

                //var applicationUser = DecryptObject<ApplicationUser>(userData);
                //if(applicationUser != null)
                //{
                //    UserContext.FirstName = applicationUser.FirstName;
                //    UserContext.LastName = applicationUser.LastName;
                //    UserContext.IsCastingProfessional = applicationUser.IsCastingProfessional;
                //}
            }

        }
        #endregion

    }
}
