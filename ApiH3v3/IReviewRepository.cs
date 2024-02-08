namespace ApiH3v3
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetAllReviews();
        Task<IEnumerable<Review>> GetReviewsByCarId(int carId);
        Task<Review> GetReviewById(int id);
        Task<Review> AddReview(Review review);
        Task<Review> UpdateReview(int id, Review review);
        Task<bool> DeleteReview(int id);
    }
}
