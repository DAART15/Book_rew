using Book_rew.Database;
using Book_rew.Interfaces;
using Book_rew.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_rew.Repositories
{
    public class ReviewRepository(AplicationDbContext _dbContext) : IReviewRepository
    {
        public async Task<IList<Review>> GetAllRewievsDBAsync()
        {
            return await _dbContext.Reviews.ToListAsync();
        }
        public async Task<Review> CreateReviewDBAsync(Review review)
        {
            _dbContext.Reviews.Add(review);
            await _dbContext.SaveChangesAsync();
            return review;
        }
        public async Task<List<Review>> GetReviewsByBookIdDBAsync(int bookId)
        {
            return await _dbContext.Reviews.Where(r =>r.BookId == bookId).ToListAsync();
        }
    }
}
