using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiH3v3.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _context;

        public ReviewRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Review>> GetAllReviews()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetReviewsByCarId(int carId)
        {
            return await _context.Reviews.Where(r => r.CarId == carId).ToListAsync();
        }

        public async Task<Review> GetReviewById(int id)
        {
            return await _context.Reviews.FindAsync(id);
        }

        public async Task<Review> AddReview(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<Review> UpdateReview(int id, Review review)
        {
            var existingReview = await _context.Reviews.FindAsync(id);
            if (existingReview == null)
                return null;

            existingReview.CarId = review.CarId;
            existingReview.ReviewText = review.ReviewText;
            existingReview.Rating = review.Rating;

            await _context.SaveChangesAsync();
            return existingReview;
        }

        public async Task<bool> DeleteReview(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
                return false;

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
