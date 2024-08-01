namespace Book_rew.Interfaces
{
    public interface IAccountService
    {
        void Register(string username, string password);
        bool Login(string username, string password, out string role);
    }
}
