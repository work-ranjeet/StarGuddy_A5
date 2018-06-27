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
using System.Linq;
using System.Security.Claims;
using System.Text;
//using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace StarGuddy.Api.Controllers
{
    public abstract class BaseApiController : Controller
    {
        protected IUserContext UserContext { get; set; }

        protected string JwtToken
        {
            get
            {
                var autherizationToken = HttpContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault();
                return autherizationToken.Value.ToString();
            }
        }
        
        protected JwtSecurityToken DecodeJwtToken(string jwtInput)
        {
            var jwtHandler = new JwtSecurityTokenHandler();

            var readableToken = jwtHandler.CanReadToken(jwtInput);

            if (readableToken == true)
            {
                var token = jwtHandler.ReadJwtToken(jwtInput);

                //Extract the headers of the JWT
                var headers = token.Header;
                var jwtHeader = "{";
                foreach (var h in headers)
                {
                    jwtHeader += '"' + h.Key + "\":\"" + h.Value + "\",";
                }
                jwtHeader += "}";
                //txtJwtOut.Text = "Header:\r\n" + JToken.Parse(jwtHeader).ToString(Formatting.Indented);

                //Extract the payload of the JWT
                var claims = token.Claims;
                var jwtPayload = "{";
                foreach (Claim c in claims)
                {
                    jwtPayload += '"' + c.Type + "\":\"" + c.Value + "\",";
                }
                jwtPayload += "}";
                //txtJwtOut.Text += "\r\nPayload:\r\n" + JToken.Parse(jwtPayload).ToString(Formatting.Indented);
            }


            var jwtToken = jwtHandler.ReadJwtToken(jwtInput) as JwtSecurityToken;

            return null;
        }
    }
}
