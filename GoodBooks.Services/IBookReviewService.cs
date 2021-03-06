using System.Collections.Generic;
using GoodBooks.Data.Models;

namespace GoodBooks.Services
{
    public interface IBookReviewService
    {
        public List<BookReview> GetAllBookReviews();
        public BookReview GetBookReview(int bookId);
        public void AddBookReview(BookReview book);
        public void DeleteBookReview(int bookId);
        
    }
}