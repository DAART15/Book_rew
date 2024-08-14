using Book_rew.DTOs;

namespace Book_rew.Interfaces
{
    public interface IReviewService
    {
        Task<ResponseDto<ReviewDto>> GetAllReviews();
        Task<ResponseDto<ReviewDto>> SaveReview(ReviewDto reviewDto);
    }
}
