using System.Collections.Generic;
using System.Threading.Tasks;
using Authentication.Models;
using Authentication.Repositories;
using Authentication.Repositories.Queries;
using System.Linq;
using System.Data;
using Dapper;
using System;

namespace Authentication.Repositories
{
    public class UserRepository : DomainRepository<User>, IUserRepository
    {
        public UserRepository(IDatabaseProvider provider) : base(provider)
        {
        }

        public UserRepository(IDbConnection databaseConnection, IDbTransaction transaction = null) : base(databaseConnection, transaction)
        {
        }

        protected string SelectAllQuery => $"SELECT * FROM accounts";

        public async Task<User> GetUserAsync(string username)
        {
            var users = await dbConn.QueryAsync<User>(UserQueries.GET_USER_BY_USERNAME, new { username }, transaction: dbTransaction).ConfigureAwait(false);
            return users.FirstOrDefault();
        }

        public async Task<int> Insert(User user)
        {
            return await dbConn.ExecuteScalarAsync<int>(UserQueries.INSERT, user, transaction: dbTransaction).ConfigureAwait(false);
        }
    }
}