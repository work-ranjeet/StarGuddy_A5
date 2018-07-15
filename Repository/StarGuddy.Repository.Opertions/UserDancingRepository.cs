using StarGuddy.Data.Entities;
using StarGuddy.Repository.Base;
using StarGuddy.Repository.Configuration;
using StarGuddy.Repository.Interface;
using StarGuddy.Repository.Opertions.Constants;

namespace StarGuddy.Repository.Operation
{
    public class UserDancingRepository : RepositoryAbstract<UserDancing>, IUserDancingRepository
    {
        public UserDancingRepository(IConfigurationSingleton configurationSingleton) : base(configurationSingleton, SqlTable.UserDancing) { }

    }
}
