using Library.Application.ViewModels;
using MediatR;

namespace Library.Application.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<BaseResponse<List<BooksViewModel>>>
    {
    }
}
