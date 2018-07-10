using StarGuddy.Api.Models.Interface.Profile;
using StarGuddy.Api.Models.Profile;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarGuddy.Business.Interface.Profile
{
    public interface IProfileManager
    {
        Task<IPhysicalAppearanceModal> GetPhysicalAppreance(System.Guid userId);

        Task<bool> PerformSave(IPhysicalAppearanceModal physicalAppearance);

        Task<IEnumerable<IUserCreditModel>> GetUserCredits(Guid userId);

        Task<bool> SaveUserCredits(Guid UserId, List<UserCreditModel> userCreditModelList);

        Task<bool> DeleteUserCredits(Guid Id);
    }
}
