using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Api.Models.Interface.Profile
{
    public interface IUserCreditModel
    {
        Guid Id { get; set; }

        string Action { get; set; }

        Int32 Year { get; set; }

        String WorkPlace { get; set; }

        String Description { get; set; }
    }
}
