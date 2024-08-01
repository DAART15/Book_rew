namespace Book_rew.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(string username, string role);
    }
}
