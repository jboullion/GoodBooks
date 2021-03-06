using System;
using System.Collections.Generic;
using System.Linq;
using GoodBooks.Data;
using GoodBooks.Data.Models;

namespace GoodBooks.Services
{
    public class BookReviewService : IBookReviewService
    {
        private readonly GoodBooksDbContext _db;
        
        public BookReviewService(GoodBooksDbContext db)
        {
            _db = db;
        }
        
        public List<BookReview> GetAllBookReviews()
        {
            return _db.BookReviews.ToList();
        }

        public BookReview GetBookReview(int reviewId)
        {
            //var book = _db.Books.First(book => book.Id == bookId);
            //var book = _db.Books.FirstOrDefault(book => book.Id == bookId);
            return _db.BookReviews.Find(reviewId);
        }

        public void AddBookReview(BookReview review)
        {
            _db.Add(review);
            _db.SaveChanges();
        }

        public void DeleteBookReview(int reviewId)
        {
            var reviewToDelete = _db.BookReviews.Find(reviewId);
            
            if (reviewToDelete != null)
            {
                _db.Remove(reviewToDelete);
                _db.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Can't delete review that doesn't exist");
            }
        }
    }
}
