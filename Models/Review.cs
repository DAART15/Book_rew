using System.ComponentModel.DataAnnotations;

namespace Book_rew.Models
{
    public class Review
    {
        public int Id { get; set; }
        public Book BookId {  get; set; }
        public string ReviewerName { get; set; }
        [Range(1,5)]
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
