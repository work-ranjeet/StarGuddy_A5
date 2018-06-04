using StarGuddy.Data.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Business.Interface.Profile
{
    public interface IProfileManager
    {
        Task<bool> PerformSave(IPhysicalAppearance physicalAppearance);
    }
}
