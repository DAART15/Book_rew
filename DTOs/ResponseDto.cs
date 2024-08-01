using Book_rew.Models;

namespace Book_rew.DTOs
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public Book BookObject { get; set; }
        public List<Book> BookList { get; set; }

        public ResponseDto(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public ResponseDto(bool isSuccess, Book objectToReturn)
        {
            IsSuccess = isSuccess;
            BookObject = objectToReturn;
        }
        public ResponseDto(bool isSuccess, List<Book> bookList)
        {
            IsSuccess = isSuccess;
            BookList = bookList;
        }
    }
}
