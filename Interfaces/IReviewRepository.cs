using Book_rew.Models;
using System.Threading.Tasks;

namespace Book_rew.Interfaces
{
    public interface IReviewRepository
    {
        Task<IList<Review>> GetAllRewievsDBAsync();
        Task<Review> CreateReviewDBAsync(Review review);
    }
}
