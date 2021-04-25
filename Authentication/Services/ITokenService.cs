using Authentication.Models;

namespace Authentication.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}