using System.Threading.Tasks;
using System.Collections.Generic;
using System.Transactions;
using System;
using System.Data;

namespace Authentication.Repositories
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> QueryAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
    }
}