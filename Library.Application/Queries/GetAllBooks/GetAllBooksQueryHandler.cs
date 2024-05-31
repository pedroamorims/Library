using Library.Application.ViewModels;
using Library.Core.Repositories;
using MediatR;

namespace Library.Application.Queries.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BooksViewModel>>
    {
        private readonly IBookRepository _bookRepository;
        public GetAllBooksQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<List<BooksViewModel>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAllAsync();

            var booksViewModel = books
                .Select(b => new BooksViewModel(b.Id, b.Title, b.Author, b.Active))
                .ToList();

            return booksViewModel;
        }
    }
}
