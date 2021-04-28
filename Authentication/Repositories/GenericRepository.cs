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
    public class GenericRepository : IGenericRepository
    {
        private readonly IDatabaseProvider _databaseProvider;
        public GenericRepository(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
            _databaseProvider.SetStringConnection("Databases::DefaultConnection");
        }
        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var connection = _databaseProvider.GetConnection())
            {
                try
                {
                    return await connection.QueryAsync<T>(
                        sql: sql,
                        param: param,
                        commandTimeout: commandTimeout,
                        commandType: commandType
                        ).ConfigureAwait(false);
                }
                catch (SqlException)
                {
                    // handle error here
                    return default;
                }
            }
        }

        public async Task<int> ExecuteAsync(string sql, object param = null, int? commandTimeout = null)
        {
            using (var connection = _databaseProvider.GetConnection())
            {
                TryOpenConnection(connection);
                using (var transaction = TryBeginTransaction(connection))
                {
                    try
                    {
                        var content = await connection.ExecuteAsync(
                            sql: sql,
                            param: param,
                            transaction: transaction,
                            commandTimeout: commandTimeout
                            ).ConfigureAwait(false);

                        transaction.Commit();

                        return content;
                    }
                    catch (SqlException)
                    {
                        // handle error here
                        return default;
                    }
                }
            }
        }

        public async Task<T> ExecuteScalarAsync<T>(string sql, object param = null, int? commandTimeout = null)
        {
            using (var connection = _databaseProvider.GetConnection())
            {
                TryOpenConnection(connection);
                using (var transaction = TryBeginTransaction(connection))
                {
                    try
                    {
                        var content = await connection.ExecuteScalarAsync<T>(
                            sql: sql,
                            param: param,
                            transaction: transaction,
                            commandTimeout: commandTimeout
                            ).ConfigureAwait(false);

                        transaction.Commit();

                        return content;
                    }
                    catch (SqlException)
                    {
                        // handle error here
                        return default;
                    }
                }
            }
        }

        private void TryOpenConnection(IDbConnection connection)
        {
            try
            {
                connection.Open();
            }
            catch (Exception)
            {
                // handle error here
            }
        }

        private IDbTransaction TryBeginTransaction(IDbConnection connection)
        {
            try
            {
                return connection.BeginTransaction();
            }
            catch (Exception)
            {
                // handle error here
                return default;
            }
        }
    }
}