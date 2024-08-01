namespace Book_rew.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] Password { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }
    }
}
