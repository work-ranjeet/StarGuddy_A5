using Dapper;
using StarGuddy.Data.Entities;
using StarGuddy.Repository.Base;
using StarGuddy.Repository.Configuration;
using StarGuddy.Repository.Interface;
using StarGuddy.Repository.Opertions.Constants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Repository.Operations
{
    public class UserModelingRepository : RepositoryAbstract<UserModeling>, IUserModelingRepository
    {
        public UserModelingRepository(IConfigurationSingleton configurationSingleton) : base(configurationSingleton, SqlTable.UserModeling) { }

        public async Task<UserModelingDetails> GetUserModelingDetailAsync(Guid userId)
        {
            try
            {
                using (var conn = await Connection.OpenConnectionAsync())
                {
                    var param = new
                    {
                        UserId = userId
                    };

                    using (var multi = await conn.QueryMultipleAsync(SpNames.UserModeling.SelectDetail, param, commandType: CommandType.StoredProcedure))
                    {
                        return new UserModelingDetails
                        {
                            UserModeling = multi.ReadSingleOrDefault<UserModeling>(),
                            ModelingRoles = multi.Read<ModelingRoles>()
                        };

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
