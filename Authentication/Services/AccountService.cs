using System.Threading.Tasks;
using Authentication.Dtos.Request;
using Authentication.Repositories;
using Authentication.Infrastructure;

namespace Authentication.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        private readonly ITokenService _tokenService;
        public AccountService(IUserRepository userRepository, IPasswordHasher passwordHasher, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public async Task<string> Login(string username, string password)
        {
            var account = await _userRepository.GetUserAsync(username).ConfigureAwait(false);
            if (account != null && Authenticate(account.Password, password))
            {
                var token = _tokenService.GenerateToken(account);
                return token;
            }
            return null;
        }
        public bool Authenticate(string hashedPassword, string password)
        {
            return _passwordHasher.VerifyHashedPassword(hashedPassword, password);
        }
    }
}