// -------------------------------------------------------------------------------
// <copyright file="AddressRepository.cs" company="StarGuddy India">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------
// File Description:
// =================  
// This class file contains properties of customer details.
// -------------------------------------------------------------------------------
// Author: Ranjeet Kumar
// Date Created: 01/01/2018
// -------------------------------------------------------------------------------
// Change History:
// ===============
// Date Changed: 
// Change Description:
// -------------------------------------------------------------------------------
namespace StarGuddy.Repository.Operations
{
    #region Imports
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using StarGuddy.Data.Entities;
    using StarGuddy.Data.Entities.Interface;
    using StarGuddy.Repository.Base;
    using StarGuddy.Repository.Configuration;
    using StarGuddy.Repository.Interfaces;
    #endregion

    /// <summary>
    /// Address Repository
    /// </summary>
    /// <seealso cref="StarGuddy.Data.Repository.RepositoryAbstract{StarGuddy.Data.Entities.UserAddress}" />
    /// <seealso cref="StarGuddy.Data.Repository.RepositoryAbstract" />
    /// <seealso cref="StarGuddy.Data.Repository.Interfaces.IAddressRepository" />
    public class AddressRepository : RepositoryAbstract<UserAddress>, IAddressRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressRepository" /> class.
        /// </summary>
        /// <param name="configurationSingleton">The configuration singleton.</param>
        public AddressRepository(IConfigurationSingleton configurationSingleton) : base(configurationSingleton, "UserAddresses")
        {
        }

        /// <summary>
        /// Gets the user address asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        /// User Address
        /// </returns>
        public async Task<IUserAddress> GetUserAddressAsync(string userId)
        {
            return await Task.Factory.StartNew(() =>
            {
                try
                {
                    using (var conn = base.GetOpenConnectionAsync)
                    {
                        var param = new DynamicParameters();
                        param.Add("@UserId", userId);
                        var userSocilaAddVMist = SqlMapper.QueryAsync<IUserAddress>(conn, "SelectUserAddress", param, commandType: CommandType.StoredProcedure);

                        return userSocilaAddVMist.Result.FirstOrDefault();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
        }
    }
}
