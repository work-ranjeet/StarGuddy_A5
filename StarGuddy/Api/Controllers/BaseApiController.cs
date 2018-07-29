using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StarGuddy.Core.Context;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
//using System.Net.Http.Headers;

namespace StarGuddy.Api.Controllers
{
    public abstract class BaseApiController : Controller
    {
        #region /// properties
        private string JwtToken => HttpContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.ToString();

        //public IUserContext UserContext { get; private set; }
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

                UserContext.Current.IsAuthenticated = true;
                UserContext.Current.UserId = Guid.Parse((userPayloadToken).Claims.FirstOrDefault(m => m.Type == JwtRegisteredClaimNames.Sid).Value);
                UserContext.Current.UserName = (userPayloadToken).Claims.FirstOrDefault(m => m.Type == JwtRegisteredClaimNames.Email).Value;
                UserContext.Current.Email = (userPayloadToken).Claims.FirstOrDefault(m => m.Type == JwtRegisteredClaimNames.Email).Value;

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
