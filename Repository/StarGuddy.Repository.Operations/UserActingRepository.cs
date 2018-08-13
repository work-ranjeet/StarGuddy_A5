using Dapper;
using StarGuddy.Data.Entities;
using StarGuddy.Data.Entities.Interface;
using StarGuddy.Repository.Base;
using StarGuddy.Repository.Configuration;
using StarGuddy.Repository.Interface;
using StarGuddy.Repository.Opertions.Constants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Repository.Operations
{
    public class UserActingRepository : RepositoryAbstract<UserActing>, IUserActingRepository
    {
        public UserActingRepository(IConfigurationSingleton configurationSingleton) : base(configurationSingleton, SqlTable.UserActing) { }

        public async Task<IUserActingDetail> GetUserActingDetailAsync(Guid userId)
        {           
            try
            {
                using (var conn = await Connection.OpenConnectionAsync())
                {
                    var param = new
                    {
                        UserId = userId
                    };

                    using (var multi = await conn.QueryMultipleAsync(SpNames.UserActing.SelectDetail, param, commandType: CommandType.StoredProcedure))
                    {
                        return new UserActingDetail
                        {
                            UserActing = multi.ReadFirstOrDefault<UserActing>(),
                            Languages = multi.Read<Language>(),
                            Accents = multi.Read<Accents>(),
                            AuditionsAndJobsGroup = multi.Read<AuditionsAndJobsGroup>()
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
