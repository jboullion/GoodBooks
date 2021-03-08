using System;
using System.Collections.Generic;
using System.Linq;
using GoodBooks.Data;
using GoodBooks.Data.Models;

namespace GoodBooks.Services
{
    public class BookService : IBookService
    {
        private readonly GoodBooksDbContext _db;
        
        public BookService(GoodBooksDbContext db)
        {
            _db = db;
        }
        
        public List<Book> GetAllBooks()
        {
            return _db.Books.ToList();
        }

        public Book GetBook(int bookId)
        {
            //var book = _db.Books.First(book => book.Id == bookId);
            //var book = _db.Books.FirstOrDefault(book => book.Id == bookId);
            return _db.Books.Find(bookId);
        }

        public void AddBook(Book book)
        {
            _db.Add(book);
            _db.SaveChanges();
        }

        public void DeleteBook(int bookId)
        {
            DeleteAllBookReviews(bookId);
            
            var bookToDelete = _db.Books.Find(bookId);
            
            if (bookToDelete != null)
            {
                // Delete all our reviews first
                _db.Remove(bookToDelete);
                _db.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Can't delete book that doesn't exist");
            }
        }
        
        private void DeleteAllBookReviews(int bookId)
        {
            var reviewToDelete = _db.BookReviews.Find(bookId);

            var reviewsToDelete = _db.BookReviews.Where(b => b.Book.Id == bookId);
            
            foreach (var review in reviewsToDelete)
            {
                _db.BookReviews.Remove(review);
            }
            _db.SaveChanges();
        }
    }
}
