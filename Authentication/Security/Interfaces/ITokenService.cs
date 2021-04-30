using Authentication.Domain;

namespace Authentication.Security.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}