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
using System.Text;
using System.Threading.Tasks;

namespace StarGuddy.Repository.Operations
{
    public class JobGroupRepository : RepositoryAbstract<JobGroup>, IJobGroupRepository
    {
        public JobGroupRepository(IConfigurationSingleton configurationSingleton) : base(configurationSingleton, SqlTable.JobGroup) { }


        public async Task<IEnumerable<IJobGroup>> GetActiveJobGroupAsync() => await GetAllAsync();

        public async Task<IEnumerable<JobGroup>> GetUserJobGroupByUserIdAsync(Guid userId)
        {
            using (var conn = await Connection.OpenConnectionAsync())
            {
                var param = new
                {
                    UserId = userId
                };

                return await SqlMapper.QueryAsync<JobGroup>(conn, SpNames.JobGroup.UserJobGroup, param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
