namespace Book_rew.Models
{
    public class Review
    {
        public int Id { get; set; }
        public Book BookId {  get; set; }
        public string ReviewerName { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
