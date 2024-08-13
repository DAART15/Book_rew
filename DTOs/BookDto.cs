using System.ComponentModel.DataAnnotations;

namespace Book_rew.DTOs
{
    public class BookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
    }
}
