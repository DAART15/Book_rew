using Book_rew.DTOs;
using Book_rew.Models;

namespace Book_rew.Interfaces
{
    public interface IBookService<T> where T : Book
    {
        Task<ResponseDto<T>> GetAllBooksAsync();
        Task<ResponseDto<T>> GetBookByIDAsync(int id);
        Task<ResponseDto<T>> CreateBookAsync(T book);
        Task<ResponseDto<T>> UpdateBookAsync(T book);
        Task<ResponseDto<T>> DeleteBookAsync(int id);
    }
}
