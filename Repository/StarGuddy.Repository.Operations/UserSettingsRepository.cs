using StarGuddy.Data.Entities;
using StarGuddy.Data.Entities.Interface;
using StarGuddy.Repository.Base;
using StarGuddy.Repository.Configuration;
using StarGuddy.Repository.Interface;
using StarGuddy.Repository.Opertions.Constants;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Repository.Operations
{
    public class UserSettingsRepository : RepositoryAbstract<UserSettings>, IUserSettingsRepository
    {
        public UserSettingsRepository(IConfigurationSingleton configurationSingleton) : base(configurationSingleton, SqlTable.UserSettings)
        {
        }

        public async Task<IUserSettings> GetUsetSettingByuserIdAsync(Guid userId)
        {
            return await base.FindActiveByUserIdAsync(userId);
        }
    }
}
