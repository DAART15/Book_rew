using Book_rew.DTOs;
using Book_rew.Models;

namespace Book_rew.Interfaces
{
    public interface IReviewService
    {
        Task<ResponseDto<ReviewDto>> GetAllReviews();
        Task<ResponseDto<ReviewDto>> SaveReview(ReviewDto reviewDto);
        Task<ResponseDto<Review>> GetReviewsByBookId(int bookId);
        Task<ResponseDto<Review>> GetReviewByBookIdAndReviewIdAsync(int bookId, int reviewId);
    }
}
