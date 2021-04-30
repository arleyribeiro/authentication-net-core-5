using System.Threading.Tasks;
using Authentication.Domain;

namespace Authentication.Services.Interfaces
{
    public interface IAccountService : IServiceBase<User>
    {
        Task<string> Login(string username, string password);
        Task<bool> Register(User user);
    }
}