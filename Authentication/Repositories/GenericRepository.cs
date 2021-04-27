using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Npgsql;

namespace Authentication.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly IDatabaseProvider _databaseProvider;
        public GenericRepository(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
            _databaseProvider.SetStringConnection("Databases::DefaultConnection");
        }
        public async Task<IEnumerable<TEntity>> QueryAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var connection = _databaseProvider.GetConnection())
            {
                try
                {
                    return await connection.QueryAsync<TEntity>(
                        sql: sql,
                        param: param,
                        commandTimeout: commandTimeout,
                        commandType: commandType
                        ).ConfigureAwait(false);
                }
                catch (SqlException)
                {
                    return default;
                }
            }
        }
    }
}