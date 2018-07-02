using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace StarGuddy.Api.Models.Interface.Account
{
    public interface IUserContext
    {
        Guid UserId { get; set; }

        string UserName { get; set; }

        string Email { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }
    }
}
