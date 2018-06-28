using StarGuddy.Api.Models.Interface.Profile;
using System.Threading.Tasks;

namespace StarGuddy.Business.Interface.Profile
{
    public interface IProfileManager
    {
        Task<IPhysicalAppearanceModal> GetPhysicalAppreance(System.Guid userId);

        Task<bool> PerformSave(IPhysicalAppearanceModal physicalAppearance);
    }
}
