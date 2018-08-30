using StarGuddy.Api.Models.Profile;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Business.Interface.Profile
{
    public interface IProfileManager
    {
        Task<ProfileHeader> GetProfileHeaderByProfileUrl(string profileUrl);

        Task<UserProfile> GetUserProfile(string profileUrl);
    }
}
