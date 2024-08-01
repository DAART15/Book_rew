using Book_rew.Models;

namespace Book_rew.Database.Data
{
    public interface IBookInitialData
    {
        List<Book> Books { get; set; }
    }

    public class BookInitialData : IBookInitialData
    {
        public List<Book> Books { get; set; } = new List<Book>()
        {
            new Book(1, "Tile", "Author", "111111111111" ),
            new Book(2, "Tile-2", "Author-2", "2222222222222" ),
            new Book(3, "Tile-3", "Author-3", "3333333333333" ),
        };
    }
}
