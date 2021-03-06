namespace GoodBooks.Web.RequestModels
{
    public class NewReviewRequest
    {
        public string ReviewContent { get; set; }
        public string ReviewAuthor { get; set; }
        public int BookId { get; set; }
    }
}