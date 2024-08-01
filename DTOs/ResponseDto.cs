using Book_rew.Models;

namespace Book_rew.DTOs
{
    public class ResponseDto<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Object { get; set; }
        public List<T> List { get; set; }

        public ResponseDto(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
        public ResponseDto(bool isSuccess, T objectToReturn)
        {
            IsSuccess = isSuccess;
            Object = objectToReturn;
        }
        public ResponseDto(bool isSuccess, List<T> bookList)
        {
            IsSuccess = isSuccess;
            List = bookList;
        }
    }
}
