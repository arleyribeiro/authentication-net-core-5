using System.Collections.Generic;
using System.Threading.Tasks;
using Authentication.Models;
using Authentication.Repositories;
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
            var users = await QueryAsync<User>("select * from accounts where username = @username;", new { username }).ConfigureAwait(false);

            return users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower());
        }

        public async Task<int> Insert(User user)
        {
            return await ExecuteScalarAsync<int>(@"INSERT INTO accounts (Username, Password, Role, created_on) 
            VALUES (@Username, @Password, @Role, now()) RETURNING ID;", user).ConfigureAwait(false);
        }
    }
}