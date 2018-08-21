using StarGuddy.Data.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Repository.Interface
{
    public interface IUserSettingsRepository
    {
        Task<IUserSettings> GetUsetSettingByuserIdAsync(Guid userId);
    }
}
