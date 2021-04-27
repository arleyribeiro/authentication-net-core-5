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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IDatabaseProvider provider) : base(provider)
        {
        }
        public async Task<User> GetUserAsync(string username)
        {
            var users = await QueryAsync("select * from accounts where username = @username;", new { username }).ConfigureAwait(false);

            return users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower());
        }
    }
}