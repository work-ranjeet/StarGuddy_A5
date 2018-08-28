using StarGuddy.Data.Entities;
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
    public class UserDetailRepository : RepositoryAbstract<UserDetail>, IUserDetailRepository
    {
        public UserDetailRepository(IConfigurationSingleton configurationSingleton) : base(configurationSingleton, SqlTable.UserDetail) { }

        public async Task<UserDetail> GetUserDetailByUserId(Guid userId) => await FindActiveByUserIdAsync(userId);
    }
}
