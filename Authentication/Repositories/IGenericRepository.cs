using System.Threading.Tasks;
using System.Collections.Generic;
using System.Transactions;
using System;
using System.Data;

namespace Authentication.Repositories
{
    public interface IGenericRepository
    {
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<int> ExecuteAsync(string sql, object param = null, int? commandTimeout = null);
        Task<T> ExecuteScalarAsync<T>(string sql, object param = null, int? commandTimeout = null);
    }
}