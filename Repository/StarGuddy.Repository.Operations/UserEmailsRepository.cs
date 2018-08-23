namespace StarGuddy.Repository.Operations
{
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

    public class UserEmailsRepository : RepositoryAbstract<UserEmails>, IUserEmailsRepository
    {
        public UserEmailsRepository(IConfigurationSingleton configurationSingleton) : base(configurationSingleton, SqlTable.UserEmails) { }

        public async Task<bool> UpdateEmailAsync(Guid userId, string email)
        {
            try
            {
                using (var conn = base.OpenConnectionAsync)
                {
                    var param = new { UserId = userId, UserEmail = email };
                    var result = await SqlMapper.QueryAsync<IUserEmails>(conn, SpNames.UserEmails.UpdateEmail, param, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public async Task<IUserEmails> GetUserEmailAsync(string userId)
        //{
        //    return await Task.Factory.StartNew(() =>
        //    {
        //        try
        //        {
        //            using (var conn = base.GetOpenConnectionAsync)
        //            {
        //                var param = new
        //                {

        //                };

        //                var userSocilaAddVMist = SqlMapper.QueryAsync<IUserEmails>(conn, "SelectUserAddress", param, commandType: CommandType.Text);

        //                return userSocilaAddVMist.Result.FirstOrDefault();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    });
        //}
    }
}
