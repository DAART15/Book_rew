using Book_rew.Database;
using Book_rew.Interfaces;
using Book_rew.Models;

namespace Book_rew.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AplicationDbContext _dbContext;

        public AccountRepository(AplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Account account)
        {
            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();
        }
        public Account Get(string username)
        {
            return _dbContext.Accounts.FirstOrDefault(x => x.UserName == username);
        }
    }
}
