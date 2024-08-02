using Book_rew.Database;
using Book_rew.Interfaces;
using Book_rew.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_rew.Repositories
{
    public class BookRepository( AplicationDbContext _dbContext) : IBookRepository
    {
        public async Task<IList<Book>>GetAllBooksDBAsync()
        {
            return await _dbContext.Books.ToListAsync();
        }
        public async Task<Book>CreateBookDBAsync(Book book)
        {
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
            book.Author = "Created";
            return book;
        }
        public async Task<Book> UpdateBookDBAsync(Book book)
        {
            _dbContext.Books.Update(book);
            await _dbContext.SaveChangesAsync();
            book.Author = "Updated";
            return book;
        }
        public async Task<Book> DeleteBookDBAsync(Book book)
        {
            _dbContext.Remove(book);
            await _dbContext.SaveChangesAsync();
            book.Author = "Deleted";
            return book;
        }
    }
}
