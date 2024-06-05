using Library.Application.ViewModels;
using Library.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.GetAllLoans
{
    public class GetAllLoansQueryHandler : IRequestHandler<GetAllLoansQuery, BaseResponse<List<LoansViewModel>>>
    {
        private readonly ILoanRepository _loanRepository;

        public GetAllLoansQueryHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<BaseResponse<List<LoansViewModel>>> Handle(GetAllLoansQuery request, CancellationToken cancellationToken)
        {
            var loans = await _loanRepository.GetAllAsyncWithUserandBook();

            var loanViewModel = loans.Select(
                                    l => new LoansViewModel(l.Id, l.Book.Title, l.User.Email, l.LoanDate, l.ExpectedReturnDate)).ToList();

            return BaseResponse<List<LoansViewModel>>.Success(loanViewModel);

         

        }
    }
}
