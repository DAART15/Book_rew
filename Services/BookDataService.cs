using Book_rew.Database.Data;
using Book_rew.DTOs;
using Book_rew.Interfaces;
using Book_rew.Models;

namespace Book_rew.Services
{
    public class BookDataService(IBookInitialData _bookInitialData) : IBookService<Book>
    {
        public async Task<ResponseDto<Book>> GetAllBooksAsync()
        {
            var allBooks = _bookInitialData.Books;
            if (!allBooks.Any())
            {
                return new ResponseDto<Book>(false, "404");
            }
            return new ResponseDto<Book>(true, allBooks);
        }
        public async Task<ResponseDto<Book>> GetBookByIDAsync(int id)
        {
            if (id <= 0)
            {
                return new ResponseDto<Book>(false, "400");
            }
            var response = await GetAllBooksAsync();
            if (!response.IsSuccess)
            {
                return new ResponseDto<Book>(false, response.Message);
            }
            var bookById = response.List.FirstOrDefault(i => i.Id == id);
            if (bookById == null)
            {
                return new ResponseDto<Book>(false, "404");
            }
            return new ResponseDto<Book>(true, bookById);
        }
        public async Task<ResponseDto<Book>> CreateBookAsync(Book book)
        {
            if (book == null)
            {
                return new ResponseDto<Book>(false, "400");
            }
            if (book.Id != 0)
            {
                return new ResponseDto<Book>(false, "404");
            }
            var response = await GetAllBooksAsync();
            if (response.IsSuccess == false)
            {
                return new ResponseDto<Book>(false, response.Message);
            }
            var maxId = response.List.Max(i => i.Id);
            book.Id = maxId+1;
            _bookInitialData.Books.Add(book);
            return new ResponseDto<Book>(true, "");
        }
        public async Task<ResponseDto<Book>> UpdateBookAsync(Book book)
        {
            if (book.Id <= 0)
            {
                return new ResponseDto<Book>(false, "404");
            }
            var response = await GetBookByIDAsync(book.Id);
            if (response.IsSuccess == false)
            {
                return new ResponseDto<Book>(false, response.Message);
            }
            var bookToUpdate = response.Object;
            bookToUpdate.Title = book.Title;
            bookToUpdate.Author = book.Author;
            bookToUpdate.ISBN = book.ISBN;
            _bookInitialData.Books[book.Id] = bookToUpdate;
            return new ResponseDto<Book>(true, "");
        }
        public async Task<ResponseDto<Book>> DeleteBookAsync(int id)
        {
            if (id <= 0)
            {
                return new ResponseDto<Book>(false, "404");
            }
            var response = await GetBookByIDAsync(id);
            if (response.IsSuccess == false)
            {
                return new ResponseDto<Book>(false, response.Message);
            }
            var bookToDelete = response.Object;
            _bookInitialData.Books.Remove(bookToDelete);
            return new ResponseDto<Book>(true, "");
        }        
    }
}
