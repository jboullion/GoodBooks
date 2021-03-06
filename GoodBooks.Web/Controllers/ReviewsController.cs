using System;
using GoodBooks.Data.Models;
using GoodBooks.Services;
using GoodBooks.Web.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GoodBooks.Web.Controllers
{
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ILogger<ReviewsController> _logger;
        private readonly IBookReviewService _reviewService;
        private readonly IBookService _bookService;

        public ReviewsController(ILogger<ReviewsController> logger, IBookReviewService reviewService, IBookService bookService)
        {
            _logger = logger;
            _reviewService = reviewService;
            _bookService = bookService;
        }

        [HttpGet("/api/reviews")]
        public ActionResult GetReviews()
        {
            var reviews = _reviewService.GetAllBookReviews();
            return Ok(reviews);
        }
        
        [HttpGet("/api/reviews/{reviewId}")]
        public ActionResult GetReview(int reviewId)
        {
            var review = _reviewService.GetBookReview(reviewId);
            return Ok(review);
        }
        
        [HttpPost("/api/reviews")]
        public ActionResult CreateReview([FromBody] NewReviewRequest reviewRequest)
        {
            var now = DateTime.UtcNow;
            
            Book book = _bookService.GetBook(reviewRequest.BookId);
            
            var review = new BookReview
            {
                CreatedOn = now,
                UpdatedOn = now,
                ReviewContent = reviewRequest.ReviewContent,
                ReviewAuthor = reviewRequest.ReviewAuthor,
                Book = book,
            };

            _reviewService.AddBookReview(review);
            
            return Ok($"Review created: {review.ReviewContent}");
        }
        
        [HttpDelete("/api/reviews/{reviewId}")]
        public ActionResult DeleteReview(int reviewId)
        {
            _reviewService.DeleteBookReview(reviewId);
            return Ok($"Review Probably Deleted with id {reviewId} ;P");
        }
    }
}
