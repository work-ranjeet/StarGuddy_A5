using StarGuddy.Api.Models.Interface.Profile;
using StarGuddy.Api.Models.Profile;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarGuddy.Business.Interface.Profile
{
    public interface IProfileManager
    {
        Task<IPhysicalAppearanceModal> GetPhysicalAppreance();

        Task<bool> PerformSave(IPhysicalAppearanceModal physicalAppearance);

        Task<IEnumerable<IUserCreditModel>> GetUserCredits();

        Task<bool> SaveUserCredits(Guid UserId, List<UserCreditModel> userCreditModelList);

        Task<bool> DeleteUserCredits(Guid userId);


        Task<DancingModel> GetUserDancingAsync();
        Task<bool> SaveUserDancingAsync(DancingModel dancingModel);


        Task<UserActingModel> GetUserActingDetailAsync();
        Task<bool> SaveUserActingDetailsAsync(UserActingModel userActingModel);

        Task<UserModelingModel> GetUserModelingDetailAsync();
        Task<bool> SaveUserModelingDetailsAsync(UserModelingModel userModelingModel);

        Task<UserProfile> GetUserProfile(string profileUrl);
    }
}
