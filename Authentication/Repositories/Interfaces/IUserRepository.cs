using System.Threading.Tasks;
using Authentication.Domain;
using System.Collections.Generic;

namespace Authentication.Repositories.Interfaces
{
    public interface IUserRepository : IRepositoryAsync<User>
    {
        Task<User> GetUserAsync(string username);
        Task<int> Insert(User user);
    }
}