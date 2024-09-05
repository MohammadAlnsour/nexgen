using Newtonsoft.Json;
using nexgen.Domain.Entities;

namespace nexgen.Domain.Factories
{
    public class BookFactory : IBookFactory
    {
        public Book CreateBook(string bookTitle, string bookDescription, string author, DateTime publishDate, string coverBase64)
        {
            return new Book()
            {
                BookId = 0,
                LastModified = DateTime.Now,
                BookInfo = JsonConvert.SerializeObject(new
                {
                    BookTitle = bookTitle,
                    BookDescription = bookDescription,
                    Author = author,
                    PublishDate = publishDate,
                    CoverBase64 = coverBase64
                })
            };
        }
        public Book CreateBookDefault()
        {
            return new Book()
            {
                BookId = 0,
                LastModified = DateTime.Now,
                BookInfo = JsonConvert.SerializeObject(new
                {
                    BookTitle = "bookTitle",
                    BookDescription = "bookDescription",
                    Author = "author",
                    PublishDate = DateTime.Now,
                    CoverBase64 = "coverBase64"
                })
            };
        }
    }
}
