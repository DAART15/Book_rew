using Book_rew.Models;

namespace Book_rew.DTOs
{
    public class ResponseDto<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Object { get; set; }
        public IList<T> List { get; set; }
        public Status StatusCode { get; set; }

        public ResponseDto(bool isSuccess, string message, Status statusCode)
        {
            IsSuccess = isSuccess;
            Message = message;
            StatusCode = statusCode;
        }

        public ResponseDto(bool isSuccess, T objectToReturn, Status statusCode)
        {
            IsSuccess = isSuccess;
            Object = objectToReturn;
            StatusCode = statusCode;
        }

        public ResponseDto(bool isSuccess, IList<T> listToReturn, Status statusCode)
        {
            IsSuccess = isSuccess;
            List = listToReturn;
            StatusCode = statusCode;
        }
        public enum Status
        {
            Ok = 200,
            Created = 201,
            NoContent = 204,
            BadRequest = 400,
            NotFound = 404,
            InternalServerError = 500
        }
    }
}
