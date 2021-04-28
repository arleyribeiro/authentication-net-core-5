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
    public class UserRepository : GenericRepository, IUserRepository
    {
        public UserRepository(IDatabaseProvider provider) : base(provider)
        {
        }
        public async Task<User> GetUserAsync(string username)
        {
            var users = await QueryAsync<User>(UserQueries.GET_USER_BY_USERNAME, new { username }).ConfigureAwait(false);

            return users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower());
        }

        public async Task<int> Insert(User user)
        {
            return await ExecuteScalarAsync<int>(UserQueries.INSERT, user).ConfigureAwait(false);
        }
    }
}