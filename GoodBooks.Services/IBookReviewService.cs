using System.Collections.Generic;
using GoodBooks.Data.Models;

namespace GoodBooks.Services
{
    public interface IBookReviewService
    {
        public List<BookReview> GetAllBookReviews();
        public BookReview GetBookReview(int reviewId);
        public void AddBookReview(BookReview review);
        public void DeleteBookReview(int reviewId);
        
    }
}