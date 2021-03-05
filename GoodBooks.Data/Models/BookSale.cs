using System;

namespace GoodBooks.Data.Models
{
    public class BookSale
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }
        public string Customer { get; set; }
        
        public Book Book { get; set; }
    }
}