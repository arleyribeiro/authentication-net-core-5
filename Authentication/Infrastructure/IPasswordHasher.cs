using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Infrastructure
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyHashedPassword(string hashedPassword, string providedPassword);
    }
}