using Book_rew.DTOs;
using Book_rew.Interfaces;
using Book_rew.Models;

namespace Book_rew.Services
{
    public class BookService(IBookRepository _bookRepository) : IBookService<Book>
    {
        public async Task<ResponseDto<Book>> GetAllBooksAsync()
        {
            var allBooks = await _bookRepository.GetAllBooksDBAsync();
            if (!allBooks.Any() || allBooks.Count == 0)
            {
                return new ResponseDto<Book>(false, "No books found.", ResponseDto<Book>.Status.NotFound);
            }
            return new ResponseDto<Book>(true, allBooks, ResponseDto<Book>.Status.Ok);
        }
        public async Task<ResponseDto<Book>> GetBookByIDAsync(int id)
        {
            if (id <= 0)
            {
                return new ResponseDto<Book>(false, "Invalid ID.", ResponseDto<Book>.Status.BadRequest);
            }
            var response = await GetAllBooksAsync();
            if (!response.IsSuccess)
            {
                return new ResponseDto<Book>(false, response.Message, response.StatusCode);
            }
            var bookById = response.List.FirstOrDefault(i => i.Id == id);
            if (bookById == null)
            {
                return new ResponseDto<Book>(false, "Book not found.", ResponseDto<Book>.Status.NotFound);
            }
            return new ResponseDto<Book>(true, bookById, ResponseDto<Book>.Status.Ok);
        }
        public async Task<ResponseDto<Book>> CreateBookAsync(Book book)
        {
            if (book == null)
            {
                return new ResponseDto<Book>(false, "Invalid book data.", ResponseDto<Book>.Status.BadRequest);
            }
            if (book.Id != 0)
            {
                return new ResponseDto<Book>(false, "Book ID must be \"0\"", ResponseDto<Book>.Status.BadRequest);
            }
            var response = await GetAllBooksAsync();
            if (response.IsSuccess == false)
            {
                return new ResponseDto<Book>(false, response.Message, response.StatusCode);
            }
            var maxId = response.List.Max(i => i.Id);
            book.Id = maxId + 1;
            var bookAfterDB = await _bookRepository.CreateBookDBAsync(book);
            if(bookAfterDB.Author != "Created")
            {
                return new ResponseDto<Book>(false, "Book failed to Save to DB", ResponseDto<Book>.Status.InternalServerError);
            }
            return new ResponseDto<Book>(true, "Book created successfully.", ResponseDto<Book>.Status.Created);
        }
        public async Task<ResponseDto<Book>> UpdateBookAsync(Book book)
        {
            if (book.Id <= 0)
            {
                return new ResponseDto<Book>(false, "Invalid book ID.", ResponseDto<Book>.Status.BadRequest);
            }
            var response = await GetBookByIDAsync(book.Id);
            if (response.IsSuccess == false)
            {
                return new ResponseDto<Book>(false, response.Message, response.StatusCode);
            }
            var bookToUpdate = response.Object;
            bookToUpdate.Title = book.Title;
            bookToUpdate.Author = book.Author;
            bookToUpdate.ISBN = book.ISBN;
            var bookAfterDB = await _bookRepository.UpdateBookDBAsync(bookToUpdate);
            if (bookAfterDB.Author != "Updated")
            {
                return new ResponseDto<Book>(false, "Book failed to Update to DB", ResponseDto<Book>.Status.InternalServerError);
            }
            return new ResponseDto<Book>(true, "Book updated successfully.", ResponseDto<Book>.Status.Ok);
        }
        public async Task<ResponseDto<Book>> DeleteBookAsync(int id)
        {
            if (id <= 0)
            {
                return new ResponseDto<Book>(false, "Invalid book ID.", ResponseDto<Book>.Status.BadRequest);
            }
            var response = await GetBookByIDAsync(id);
            if (response.IsSuccess == false)
            {
                return new ResponseDto<Book>(false, response.Message, response.StatusCode);
            }
            var bookToDelete = response.Object;
            var bookAfterDB = await _bookRepository.DeleteBookDBAsync(bookToDelete);
            if (bookAfterDB.Author != "Deleted")
            {
                return new ResponseDto<Book>(false, "Book failed to Delete from DB", ResponseDto<Book>.Status.InternalServerError);
            }
            return new ResponseDto<Book>(true, "Book deleted successfully.", ResponseDto<Book>.Status.NoContent);
        } 
    }
}
