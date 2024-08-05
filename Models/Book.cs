using System.ComponentModel.DataAnnotations;

namespace Book_rew.Models
{
    public class Book
    {
        public Book(int id, string title, string author, string iSBN)
        {
            Id = id;
            Title = title;
            Author = author;
            ISBN = iSBN;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        [MinLength(13)]
        [MaxLength(13)]
        public string ISBN { get; set; }
        public DateTime PublishedTime { get; set; } = DateTime.Now;
    }
}
