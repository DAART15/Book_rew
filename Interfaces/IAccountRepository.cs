using Book_rew.Models;

namespace Book_rew.Interfaces
{
    public interface IAccountRepository
    {
        void Add(Account account);
        Account Get(string username);
    }
}
