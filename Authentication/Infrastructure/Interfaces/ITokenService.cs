using Authentication.Models;

namespace Authentication.Infrastructure.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}