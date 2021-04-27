using System.Threading.Tasks;

namespace Authentication.Services
{
    public interface IAccountService
    {
        Task<string> Login(string username, string password);
    }
}