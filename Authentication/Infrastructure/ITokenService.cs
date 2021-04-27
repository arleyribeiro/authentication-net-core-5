using Authentication.Models;

namespace Authentication.Infrastructure
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}