using nexgen.Domain.Entities;

namespace nexgen.Infrastructure.Dapper
{
    public interface IBookDbService
    {
        Task<IEnumerable<Book>> GetBooksPagedAsync(int pageNumber, int pageSize);
    }
}
