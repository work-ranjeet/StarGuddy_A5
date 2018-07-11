using StarGuddy.Api.Models.Interface.Profile;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Api.Models.Profile
{
    public class UserCreditModel : IUserCreditModel
    {
        public Guid Id { get; set; }

        public string Action { get; set; }

        public Int32 WorkYear { get; set; }

        public String WorkPlace { get; set; }

        public String WorkDetail { get; set; }
    }
}
