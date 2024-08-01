using Book_rew.Interfaces;
using Book_rew.Models;
using System.Security.Cryptography;
using System.Text;

namespace Book_rew.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void Register(string username, string password)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            Account account = new Account
            {
                UserName = username,
                Password = passwordHash,
                PasswordSalt = passwordSalt,
                Role = "Admin"
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
