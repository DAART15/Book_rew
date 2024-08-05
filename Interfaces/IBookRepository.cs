using Book_rew.Models;

namespace Book_rew.Interfaces
{
    public interface IBookRepository
    {
        Task<IList<Book>> GetAllBooksDBAsync();
        Task<Book> CreateBookDBAsync(Book book);
        Task<Book> UpdateBookDBAsync(Book book);
        Task<Book> DeleteBookDBAsync(Book book);
    }
}
