using Library.Application.ViewModels;
using MediatR;

namespace Library.Application.Queries.GetAllLoans
{
    public class GetAllLoansQuery : IRequest<List<LoansViewModel>>
    {
    }
}
