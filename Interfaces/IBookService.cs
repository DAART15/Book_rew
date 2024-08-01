using Book_rew.DTOs;
using Book_rew.Models;

namespace Book_rew.Interfaces
{
    public interface IBookService
    {
        Task<ResponseDto> GetAllBooksAsync();
        Task<ResponseDto> GetBookByIDAsync(int id);
        Task<ResponseDto> CreateBookAsync(Book book);
        Task<ResponseDto> UpdateBookAsync(Book book);
        Task<ResponseDto> DeleteBookAsync(int id);
    }
}
