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

        public async Task<UserActingDetail> GetUserActingDetailAsync(Guid userId)
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

        public async Task<bool> PerformSaveAndUpdateOperationAsync(UserActingDetail actingDetail)
        {
            try
            {
                using (var conn = await Connection.OpenConnectionAsync())
                {
                    using (var tran = conn.BeginTransaction())
                    {
                        try
                        {
                            conn.Execute(
                               SpNames.UserActing.ClearActingDetail,
                               param: new { actingDetail.UserActing.UserId },
                               transaction: tran,
                               commandType: CommandType.StoredProcedure);

                            //var saveTasks = new List<Task>
                            //{
                            //new Task(async () =>
                            //{
                            /* @UserId UNIQUEIDENTIFIER, @ActingExpCode INT, @AgentNeedCode INT, @Experiance NVARCHAR(2000)*/
                            var param = new DynamicParameters();
                            param.Add("@UserId", actingDetail.UserActing.UserId, DbType.Guid, ParameterDirection.Input);
                            param.Add("@ActingExpCode", actingDetail.UserActing.ActingExperianceCode, DbType.Int32, ParameterDirection.Input);
                            param.Add("@AgentNeedCode", actingDetail.UserActing.AgentNeedCode, DbType.Int32, ParameterDirection.Input);
                            param.Add("@Experiance", actingDetail.UserActing.Experiance, DbType.String, ParameterDirection.Input);
                            await conn.ExecuteAsync(SpNames.UserActing.SaveUpdate, param: param, transaction: tran, commandType: CommandType.StoredProcedure);
                            //}),


                            //new Task(async () =>
                            //{
                            // Language Save
                            if (actingDetail.Languages.Any())
                            {
                                //var v = new System.Collections.Concurrent.ConcurrentBag<Language>();
                                
                                var langTask = actingDetail.Languages.Select(async x =>
                                {
                                    var langParam = new
                                    {
                                        actingDetail.UserActing.UserId,
                                        LanguageCode = x.Code
                                    };

                                    return await conn.ExecuteAsync(SpNames.UserActing.UserLanguageSave, param: langParam, transaction: tran, commandType: CommandType.StoredProcedure);
                                });

                                var updatedResult = await Task.WhenAll(langTask);
                            }
                            //}),

                            //new Task(async () =>
                            //{
                            // Accents Save
                            if (actingDetail.Accents.Any())
                            {
                                var accTask = actingDetail.Accents.Select(async x =>
                                {
                                    var accentParam = new
                                    {
                                        actingDetail.UserActing.UserId,
                                        AccentCode = x.Code
                                    };

                                    return await conn.ExecuteAsync(SpNames.UserActing.UserAccentSave, param: accentParam, transaction: tran, commandType: CommandType.StoredProcedure);
                                });

                                var updatedResult = await Task.WhenAll(accTask);
                            }
                            //}),

                            // new Task(async () =>
                            //{
                            // Job Group Save
                            if (actingDetail.AuditionsAndJobsGroup.Any())
                            {
                                var jobGroupTask = actingDetail.AuditionsAndJobsGroup.Select(async x =>
                                {
                                    var jobGroupParam = new
                                    {
                                        actingDetail.UserActing.UserId,
                                        JobCode = x.Code
                                    };

                                    return await conn.ExecuteAsync(SpNames.UserActing.UserAuditionsAndJobsGroupSave, param: jobGroupParam, transaction: tran, commandType: CommandType.StoredProcedure);
                                });

                                var updatedResult = await Task.WhenAll(jobGroupTask);
                            }
                            //})
                            // };

                            //Task.WaitAll(saveTasks.ToArray());

                            tran.Commit();

                            return true;
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            throw ex;
                        }
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
