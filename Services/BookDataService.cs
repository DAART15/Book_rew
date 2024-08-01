using Book_rew.Database.Data;
using Book_rew.DTOs;
using Book_rew.Interfaces;
using Book_rew.Models;

namespace Book_rew.Services
{
    public class BookDataService(IBookInitialData _bookInitialData) : IBookService
    {
        public async Task<ResponseDto> GetAllBooksAsync()
        {
            var allBooks = _bookInitialData.Books;
            if (!allBooks.Any())
            {
                return new ResponseDto(false, "Books not Found");
            }
            return new ResponseDto(true, allBooks);
        }
        public async Task<ResponseDto> GetBookByIDAsync(int id)
        {
            if (id <= 0)
            {
                return new ResponseDto(false, "Invalid book Id");
            }
            var response = await GetAllBooksAsync();
            if (response.IsSuccess == false)
            {
                return new ResponseDto(false, response.Message);
            }
            var bookById = response.BookList.FirstOrDefault(i => i.Id == id);
            if (bookById == null)
            {
                return new ResponseDto(false, "Book with this Id not Found");
            }
            return new ResponseDto(true, bookById);
        }
        public async Task<ResponseDto> CreateBookAsync(Book book)
        {
            if (book == null)
            {
                return new ResponseDto(false, "Book must be not null");
            }
            if (book.Id != 0)
            {
                return new ResponseDto(false, "When Creating Book Id must be \"0\"");
            }
            var response = await GetAllBooksAsync();
            if (response.IsSuccess == false)
            {
                return new ResponseDto(false, response.Message);
            }
            var maxId = response.BookList.Max(i => i.Id);
            book.Id = maxId+1;
            _bookInitialData.Books.Add(book);
            return new ResponseDto(true, "");
        }
        public async Task<ResponseDto> UpdateBookAsync(Book book)
        {
            if (book.Id <= 0)
            {
                return new ResponseDto(false, "Invalid book Id");
            }
            var response = await GetBookByIDAsync(book.Id);
            if (response.IsSuccess == false)
            {
                return new ResponseDto(false, response.Message);
            }
            var bookToUpdate = response.BookObject;
            bookToUpdate.Title = book.Title;
            bookToUpdate.Author = book.Author;
            bookToUpdate.ISBN = book.ISBN;
            _bookInitialData.Books[book.Id] = bookToUpdate;
            return new ResponseDto(true, "Book Updated");
        }
        public async Task<ResponseDto> DeleteBookAsync(int id)
        {
            if (id <= 0)
            {
                return new ResponseDto(false, "Invalid book Id");
            }
            var response = await GetBookByIDAsync(id);
            if (response.IsSuccess == false)
            {
                return new ResponseDto(false, response.Message);
            }
            var bookToDelete = response.BookObject;
            _bookInitialData.Books.Remove(bookToDelete);
            return new ResponseDto(true, "Book deleted");
        }        
    }
}
