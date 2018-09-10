using StarGuddy.Api.Models.Interface.Profile;
using StarGuddy.Api.Models.Profile;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Business.Interface.Profile
{
    public interface IProfileFacade
    {
        Task<IPhysicalAppearanceModal> FetchPhysicalAppreance(Guid userId);

        Task<IEnumerable<IUserCreditModel>> FetchUserCredits(Guid userId);

        Task<DancingModel> FetchUserDancingAsync(Guid userId);

        Task<UserActingModel> FetchUserActingDetailAsync(Guid userId);

        Task<UserModelingModel> FetchUserModelingDetailAsync(Guid userId);

        Task<UserNameModel> FetchNameDetailsByUserId(Guid userId);

        Task<ProfileHeader> FetchProfileHeaderByUserId(Guid userId);

        Task<UserDetailModel> FetchProfileDetail(Guid userId);
    }
}
