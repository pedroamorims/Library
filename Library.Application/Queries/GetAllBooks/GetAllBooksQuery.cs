using Library.Application.ViewModels;
using MediatR;

namespace Library.Application.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<List<BooksViewModel>>
    {
    }
}
