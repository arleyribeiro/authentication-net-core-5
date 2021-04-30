using Authentication.Models;

namespace Authentication.Security.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}