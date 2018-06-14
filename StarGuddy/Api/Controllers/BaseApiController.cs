using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarGuddy.Api.Controllers
{
    public abstract class BaseApiController : Controller
    {
        public void UserId()
        {
            //read cookie from IHttpContextAccessor  
            string userId = HttpContext.Request.Cookies["UserId"];

            //read cookie from Request object  
            string cookieValueFromReq = Request.Cookies["UserId"];
        }
    }
}
