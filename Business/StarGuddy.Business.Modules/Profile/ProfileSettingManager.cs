using StarGuddy.Business.Interface.Profile;
using StarGuddy.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Business.Modules.Profile
{
    public class ProfileSettingManager : IProfileSettingManager
    {
        private IUserEmailsRepository userEmailsRepository;

        public ProfileSettingManager(IUserEmailsRepository userEmailsRepository)
        {
            this.userEmailsRepository = userEmailsRepository;
        }

        public async Task<bool> UpdateEmail(Guid userId, string email)
        {
            return await this.userEmailsRepository.UpdateEmailAsync(userId, email);
        }
    }
}
