using Book_rew.DTOs;
using Book_rew.Interfaces;
using Book_rew.Models;

namespace Book_rew.Services
{
    public class BookService : IBookService
    {
        public Task<ResponseDto> CreateBookAsync(Book book)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> DeleteBookAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> GetAllBooksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> GetBookByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto> UpdateBookAsync(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
