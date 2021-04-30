using System.Threading.Tasks;
using Authentication.Models;
using System.Collections.Generic;

namespace Authentication.Repositories.Interfaces
{
    public interface IUserRepository : IDomainRepository<User>
    {
        Task<User> GetUserAsync(string username);
        Task<int> Insert(User user);
    }
}