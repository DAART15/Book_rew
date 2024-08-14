using Book_rew.Models;
using System.ComponentModel.DataAnnotations;

namespace Book_rew.DTOs
{
    public class ReviewDto
    {
        public int BookId { get; set; }
        public string ReviewerName { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
