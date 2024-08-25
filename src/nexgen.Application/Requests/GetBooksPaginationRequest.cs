using nexgen.Application.Contracts.DTOs;
using MediatR;

namespace nexgen.Application.Requests
{
    public class GetBooksPaginationRequest : IRequest<IEnumerable<BookReponseDTO>>
    {
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        public GetBooksPaginationRequest(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
