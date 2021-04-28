using System.Threading.Tasks;
using Authentication.Models;

namespace Authentication.Services
{
    public interface IAccountService
    {
        Task<string> Login(string username, string password);
        Task<bool> Register(User user);
    }
}