using System.Threading.Tasks;
using Authentication.Models;

namespace Authentication.Services
{
    public interface IAccountService : IServiceBase<User>
    {
        Task<string> Login(string username, string password);
        Task<bool> Register(User user);
    }
}