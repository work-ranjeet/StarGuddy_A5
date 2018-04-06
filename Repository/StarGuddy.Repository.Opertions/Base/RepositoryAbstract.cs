// -------------------------------------------------------------------------------
// <copyright file="RepositoryAbstract.cs" company="StarGuddy India">
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
namespace StarGuddy.Repository.Base
{
    #region Imports
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Dapper;
    using StarGuddy.Repository.Configuration;
    using System.Threading.Tasks;
    #endregion

    /// <summary>
    /// Repository Abstract With Generic Function
    /// </summary>
    /// <typeparam name="T">Generic parameter</typeparam>
    /// <seealso cref="System.IDisposable" />
    /// <inheritdoc />
    public abstract class RepositoryAbstract<T> : IDisposable
    {
        /// <summary>
        /// The table name
        /// </summary>
        private readonly string tableName;

        /// <summary>
        /// The configuration singleton
        /// </summary>
        private readonly IConfigurationSingleton configurationSingleton;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryAbstract{T}" /> class.
        /// </summary>
        /// <param name="configurationSingleton">The configuration singleton.</param>
        /// <param name="tableName">Name of the table.</param>
        public RepositoryAbstract(IConfigurationSingleton configurationSingleton, string tableName)
        {
            this.configurationSingleton = configurationSingleton;
            this.tableName = tableName;
        }

        /// <summary>
        /// Creation an object of SQL connection
        /// </summary>
        /// <value>
        /// The SQL connection.
        /// </value>
        protected SqlConnection _SqlConnection => new SqlConnection(this.configurationSingleton.SQLConnectionString);

        /// <summary>
        /// Gets a value indicating whether this instance is connection open.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is connection open; otherwise, <c>false</c>.
        /// </value>
        protected bool IsConnectionOpen => this._SqlConnection.State == ConnectionState.Open;

        /// <summary>
        /// Gets the open connection.
        /// </summary>
        /// <value>
        /// The get open connection.
        /// </value>
        protected SqlConnection GetOpenConnection
        {
            get
            {
                if (this._SqlConnection.State == ConnectionState.Closed || this._SqlConnection.State == ConnectionState.Broken)
                {
                    this._SqlConnection.Open();
                }

                return this._SqlConnection;
            }
        }

        /// <summary>
        /// Gets the get open connection asynchronous.
        /// </summary>
        /// <value>
        /// The get open connection asynchronous.
        /// </value>
        protected SqlConnection GetOpenConnectionAsync
        {
            get
            {
                if (this._SqlConnection.State == ConnectionState.Closed || this._SqlConnection.State == ConnectionState.Broken)
                {
                    this._SqlConnection.OpenAsync();
                }

                return this._SqlConnection;
            }
        }

        /// <summary>
        /// Gets the sequence identifier.
        /// </summary>
        /// <value>
        /// The get sequence identifier.
        /// </value>
        protected Guid GetSequenceId
        {
            get
            {
                using (var conn = this.GetOpenConnectionAsync)
                {
                    var result = SqlMapper.QueryAsync(conn, "select NEWID()");

                    return new Guid(result.Result.ToString());
                }
            }
        }

        /// <summary>
        /// Finds the single.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        /// Generic Type
        /// </returns>
        public virtual T FindSingle(string query, dynamic parameter)
        {
            using (var conn = this.GetOpenConnection)
            {
                return conn.QueryFirstOrDefault<T>(query, (object)parameter);
            }
        }
        public virtual async Task<T> FindSingleAsync(string query, dynamic parameter)
        {
            using (var conn = this.GetOpenConnectionAsync)
            {
                return await conn.QueryFirstOrDefaultAsync<T>(query, (object)parameter);
            }
        }

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>
        /// Query to get all entities
        /// </returns>
        public virtual IEnumerable<T> GetAll()
        {
            using (var connection = this.GetOpenConnection)
            {
                return connection.Query<T>("SELECT * FROM " + this.tableName);
            }
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            using (var connection = this.GetOpenConnectionAsync)
            {
                return await connection.QueryAsync<T>("SELECT * FROM " + this.tableName);
            }
        }

        /// <summary>
        /// Gets all by parameter.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        /// Query to get all entities
        /// </returns>
        public virtual IEnumerable<T> GetAllByParameter(string query, dynamic parameter)
        {
            using (var connection = this.GetOpenConnection)
            {
                return SqlMapper.Query<T>(connection, query, parameter, commandType: CommandType.Text);
            }
        }
        public virtual async Task<IEnumerable<T>> GetAllByParameterAsync(string query, dynamic parameter)
        {
            using (var connection = this.GetOpenConnectionAsync)
            {
                return await SqlMapper.QueryAsync<T>(connection, query, parameter, commandType: CommandType.Text);
            }
        }

        /// <summary>
        /// Gets the procedure data.
        /// </summary>
        /// <param name="storeProcedureName">Name of the store procedure.</param>
        /// <returns>
        /// Query to get all entities
        /// </returns>
        public virtual IEnumerable<T> GetProcedureData(string storeProcedureName)
        {
            using (var connection = this.GetOpenConnection)
            {
                return SqlMapper.Query<T>(connection, storeProcedureName, commandType: CommandType.StoredProcedure);
            }
        }
        public virtual async Task<IEnumerable<T>> GetProcedureDataAsync(string storeProcedureName)
        {
            using (var connection = this.GetOpenConnectionAsync)
            {
                return await SqlMapper.QueryAsync<T>(connection, storeProcedureName, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Gets the procedure data.
        /// </summary>
        /// <param name="storeProcedureName">Name of the store procedure.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        /// Query to get all entities
        /// </returns>
        public virtual IEnumerable<T> GetProcedureData(string storeProcedureName, dynamic parameter)
        {
            using (var connection = this.GetOpenConnection)
            {
                return SqlMapper.Query<T>(connection, storeProcedureName, parameter, commandType: CommandType.StoredProcedure);
            }
        }
        public virtual async Task<IEnumerable<T>> GetProcedureDataAsync(string storeProcedureName, dynamic parameter)
        {
            using (var connection = this.GetOpenConnectionAsync)
            {
                return await SqlMapper.QueryAsync<T>(connection, storeProcedureName, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Finds the by identifier.
        /// </summary>
        /// <param name="id">The id.</param>
        public virtual T FindById(Guid id)
        {
            using (var conn = this.GetOpenConnection)
            {
                return SqlMapper.Query<T>(conn, "SELECT * FROM " + this.tableName + " WHERE ID = @ID", new { ID = id }, commandType: CommandType.Text).FirstOrDefault();
            }
        }
        public virtual async Task<T> FindByIdAsync(Guid id)
        {
            using (var conn = this.GetOpenConnectionAsync)
            {
                return (await SqlMapper.QueryAsync<T>(conn, "SELECT * FROM " + this.tableName + " WHERE ID = @ID", new { ID = id }, commandType: CommandType.Text)).FirstOrDefault();
            }
        }

        public virtual T FindByUserId(Guid userId)
        {
            using (var conn = this.GetOpenConnection)
            {
                return SqlMapper.Query<T>(conn, "SELECT * FROM " + this.tableName + " WHERE UserId = @UserId", new { UserId = userId }, commandType: CommandType.Text).FirstOrDefault();
            }
        }
        public virtual async Task<T> FindByUserIdAsync(Guid userId)
        {
            using (var conn = this.GetOpenConnectionAsync)
            {
                return (await SqlMapper.QueryAsync<T>(conn, "SELECT * FROM " + this.tableName + " WHERE UserId = @UserId", new { UserId = userId }, commandType: CommandType.Text)).FirstOrDefault();
            }
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">The id.</param>
        public virtual void Delete(Guid id)
        {
            using (var conn = this.GetOpenConnection)
            {
                conn.Execute("DELETE FROM " + this.tableName + " WHERE ID = @ID", new { ID = id });
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }
    }
}
