﻿using System.Data.SqlClient;
using System.Threading.Tasks;

namespace System.Data
{
    public static class SqlDataBase
    {
        public static async Task<SqlConnection> OpenConnectionAsync(this SqlConnection conn)
        {
            if (conn.State == ConnectionState.Broken || conn.State == ConnectionState.Closed)
            {
                await conn.OpenAsync().ConfigureAwait(false);                
            }

            return conn;
        }

    }
}
