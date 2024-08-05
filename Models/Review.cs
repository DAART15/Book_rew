using System.ComponentModel.DataAnnotations;

namespace Book_rew.Models
{
    public class Review
    {
        public Review(int id, int bookId, string reviewerName, int rating, string comment)
        {
            Id = id;
            BookId = bookId;
            ReviewerName = reviewerName;
            Rating = rating;
            Comment = comment;
        }

        public int Id { get; set; }
        public int BookId {  get; set; }
        public string ReviewerName { get; set; }
        [Range(1,5)]
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
