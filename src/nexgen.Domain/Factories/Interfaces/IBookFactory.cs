using nexgen.Domain.Entities;

namespace nexgen.Domain.Factories.Interfaces
{
    public interface IBookFactory
    {
        public Book CreateBook(string bookTitle, string bookDescription, string author, DateTime publishDate, string coverBase64);
        public Book CreateBookDefault();
    }
}
