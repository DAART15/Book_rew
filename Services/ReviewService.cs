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
            var allReviews = await _reviewRepository.GetAllRewievsDBAsync();
            if (!allReviews.Any() || allReviews.Count == 0)
            {
                return new ResponseDto<ReviewDto>(false, "No rewievs found.", ResponseDto<ReviewDto>.Status.NotFound);
            }
            List<ReviewDto> rewievDtoList = new List<ReviewDto>();
            foreach (var rew in allReviews)
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
            var allReviews = await _reviewRepository.GetAllRewievsDBAsync();
            if (!allReviews.Any() || allReviews.Count == 0)
            {
                return new ResponseDto<ReviewDto>(false, "No rewievs found.", ResponseDto<ReviewDto>.Status.NotFound);
            }
            var maxId = allReviews.Max(i => i.Id);
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
        public async Task<ResponseDto<Review>> GetReviewsByBookId(int bookId)
        {
            if (bookId < 1)
            {
                return new ResponseDto<Review>(false, "Invalid book Id.", ResponseDto<Review>.Status.BadRequest);
            }
            var allReviews = await _reviewRepository.GetReviewsByBookIdDBAsync(bookId);
            if (!allReviews.Any() || allReviews.Count == 0)
            {
                return new ResponseDto<Review>(false, "No rewievs found.", ResponseDto<Review>.Status.NotFound);
            }
            return new ResponseDto<Review>(true, allReviews, ResponseDto<Review>.Status.Ok);
        }
    }
}
