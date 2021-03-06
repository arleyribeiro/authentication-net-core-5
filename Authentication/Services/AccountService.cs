using System;
using System.Threading.Tasks;
using Authentication.Dtos.Request;
using Authentication.Repositories;
using Authentication.Repositories.Interfaces;
using Authentication.Security;
using Authentication.Domain;
using System.Collections.Generic;
using Authentication.Services.Interfaces;
using Authentication.Security.Interfaces;

namespace Authentication.Services
{
    public class AccountService : ServiceBase<User>, IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;
        public AccountService(IUserRepository userRepository, IPasswordHasher passwordHasher, ITokenService tokenService) : base(userRepository)
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

        public async Task<bool> Register(User user)
        {
            if (user == null)
                return false;

            if (string.IsNullOrEmpty(user.Role?.Trim()) || (string.Compare(user.Role, "manager", true) > 0 && string.Compare(user.Role, "employee", true) > 0))
            {
                throw new ArgumentException("ROLE: Must be manager or employee");
            }

            return await Insert(user).ConfigureAwait(false);
        }

        private async Task<bool> Insert(User user)
        {
            try
            {
                user.Password = _passwordHasher.HashPassword(user.Password);
                var id = await _userRepository.Insert(user).ConfigureAwait(false);
                return id > 0;
            }
            catch (Exception)
            {
                // handle error
                return false;
            }
        }
    }
}