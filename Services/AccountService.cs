using Book_rew.Interfaces;
using Book_rew.Models;
using System.Security.Cryptography;
using System.Text;

namespace Book_rew.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IConfiguration _configuration;

        public AccountService(IAccountRepository accountRepository, IConfiguration configuration)
        {
            _accountRepository = accountRepository;
            _configuration = configuration;
        }

        public void Register(string username, string password, string role)
        {
            if (String.IsNullOrEmpty(role) || role.Trim() != "BestTeam")
            {
                role = "User";
            }

            if (role.Trim() == "BestTeam")
            {
                role = _configuration.GetValue<string>("AdminGuid");
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            Account account = new Account
            {
                Id = Guid.NewGuid(),
                UserName = username,
                Password = passwordHash,
                PasswordSalt = passwordSalt,
                Role = role
            };
            _accountRepository.Add(account);

        }
        public bool Login(string username, string password, out string role)
        {
            var acc = _accountRepository.Get(username);
            role = acc.Role;

            if (acc == null)
            {
                return false;
            }

            if (VerifyPasswordHash(password, acc.Password, acc.PasswordSalt))
            {
                return true;
            }

            return false;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] salt)
        {
            using var hmac = new HMACSHA512(salt);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return hash.SequenceEqual(passwordHash);

        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}
