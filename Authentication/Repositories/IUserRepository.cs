using System.Threading.Tasks;
using Authentication.Models;
using System.Collections.Generic;

namespace Authentication.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string username, string password);
    }
}