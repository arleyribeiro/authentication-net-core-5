using System.Collections.Generic;
using System.Threading.Tasks;
using Authentication.Models;
using Authentication.Repositories;
using System.Linq;

namespace Authentication.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {

        }
        public async Task<User> GetUserAsync(string username, string password)
        {
            var users = await Task.Run(() =>
            {
                return new List<User>
                {
                    new User { Id = 1, Username = "batman", Password = "batman", Role = "manager" },
                    new User { Id = 2, Username = "robin", Password = "robin", Role = "employee" }
                };
            });

            return users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password);
        }
    }
}