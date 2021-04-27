using System.Threading.Tasks;
using Authentication.Models;
using Bcrypt = BCrypt.Net.BCrypt;


namespace Authentication.Infrastructure
{
    public class BCryptPasswordHahser : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            var hashPassword = Bcrypt.HashPassword(password);
            return hashPassword;
        }
        public bool VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            return Bcrypt.Verify(providedPassword, hashedPassword);
        }
    }
}