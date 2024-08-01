using Book_rew.DTOs;
using Book_rew.Interfaces;
using Book_rew.Models;

namespace Book_rew.Services
{
    public class BookService : IBookService<Book>
    {
        public Task<ResponseDto<Book>> CreateBookAsync(Book book)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<Book>> DeleteBookAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<Book>> GetAllBooksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<Book>> GetBookByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<Book>> UpdateBookAsync(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
