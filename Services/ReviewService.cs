using Book_rew.Database;
using Book_rew.DTOs;
using Book_rew.Interfaces;
using Book_rew.Models;

namespace Book_rew.Services
{
    public class ReviewService(IReviewRepository _reviewRepository) : IReviewService
    {
        public async Task<ResponseDto<ReviewDto>> GetAllReviews()
        {
            var allRewievs = await _reviewRepository.GetAllRewievsDBAsync();
            if (!allRewievs.Any() || allRewievs.Count == 0)
            {
                return new ResponseDto<ReviewDto>(false, "No rewievs found.", ResponseDto<ReviewDto>.Status.NotFound);
            }
            List<ReviewDto> rewievDtoList = new List<ReviewDto>();
            foreach (var rew in allRewievs)
            {
                ReviewDto rewievDto = new ReviewDto
                {
                    BookId = rew.BookId,
                    ReviewerName = rew.ReviewerName,
                    Rating = rew.Rating,
                    Comment = rew.Comment,
                };
                rewievDtoList.Add(rewievDto);
            }
            return new ResponseDto<ReviewDto>(true, rewievDtoList, ResponseDto<ReviewDto>.Status.Ok);
        }
        public async Task<ResponseDto<ReviewDto>> SaveReview(ReviewDto reviewDto)
        {
            if (reviewDto == null)
            {
                return new ResponseDto<ReviewDto>(false, "Invalid rewiev data.", ResponseDto<ReviewDto>.Status.BadRequest);
            }
            if (reviewDto.ReviewerName == null)
            {
                return new ResponseDto<ReviewDto>(false, "Invalid rewier Name.", ResponseDto<ReviewDto>.Status.BadRequest);
            }
            if (reviewDto.BookId <=0)
            {
                return new ResponseDto<ReviewDto>(false, "Invalid Book Id.", ResponseDto<ReviewDto>.Status.BadRequest);
            }
            if(reviewDto.Rating == null || reviewDto.Rating <1 || reviewDto.Rating >5)
            {
                return new ResponseDto<ReviewDto>(false, "Invalid rating.", ResponseDto<ReviewDto>.Status.BadRequest);
            }
            if(reviewDto.Comment == null)
            {
                return new ResponseDto<ReviewDto>(false, "Invalid Coment.", ResponseDto<ReviewDto>.Status.BadRequest);
            }
            var response = await GetAllReviews();
            if (!response.IsSuccess)
            {
                return new ResponseDto<ReviewDto>(false, response.Message, response.StatusCode);
            }
            var maxId = response.List.Max(i => i.BookId);
            var review = new Review(maxId + 1, reviewDto.BookId, reviewDto.ReviewerName, reviewDto.Rating, reviewDto.Comment);
            var reviewResponse = await _reviewRepository.CreateReviewDBAsync(review);
            if( reviewResponse != review)
            {
                return new ResponseDto<ReviewDto>(false, "Unable to save to DB", ResponseDto<ReviewDto>.Status.InternalServerError);
            }
            else
            {
                return new ResponseDto<ReviewDto>(true, "Review Created Successfully", ResponseDto<ReviewDto>.Status.Created);
            }
            
        }
    }
}
