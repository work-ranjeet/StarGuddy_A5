using StarGuddy.Api.Models.Interface.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Api.Models.Account
{
    public class UserContext : IUserContext
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
