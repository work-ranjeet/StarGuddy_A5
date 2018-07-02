using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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
        private string JwtToken => HttpContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.ToString();

        public IUserContext UserContext { get; private set; }
        #endregion

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            this.SetUserContext();
        }              

        #region /// Private methods
        private void SetUserContext()
        {
            if (string.IsNullOrWhiteSpace(JwtToken))
            {
                throw new Exception("Invalid Token.");
            }

            var innerJwtTokenArr = JwtToken.Split(' ');
            if (innerJwtTokenArr.Length != 2 || !innerJwtTokenArr[0].ToLowerInvariant().Equals("bearer"))
            {
                throw new Exception("Token is missing.");
            }

            var jwtHandler = new JwtSecurityTokenHandler();

            var jwtTokenInput = innerJwtTokenArr[1];
            var readableToken = jwtHandler.CanReadToken(jwtTokenInput);

            if (readableToken)
            {
                var userPayloadToken = jwtHandler.ReadJwtToken(jwtTokenInput);
                //string userData = ((userPayloadToken)).Claims.FirstOrDefault(m => m.Type == ClaimTypes.UserData).Value;

                UserContext = new UserContext
                {
                    UserId = Guid.Parse((userPayloadToken).Claims.FirstOrDefault(m => m.Type == JwtRegisteredClaimNames.Sid).Value),
                    UserName = (userPayloadToken).Claims.FirstOrDefault(m => m.Type == JwtRegisteredClaimNames.Email).Value,
                    Email = (userPayloadToken).Claims.FirstOrDefault(m => m.Type == JwtRegisteredClaimNames.Email).Value,
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
