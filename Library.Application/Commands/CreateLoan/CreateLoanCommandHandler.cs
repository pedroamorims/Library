using Library.Core.Entities;
using Library.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.CreateLoan
{
    public class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, BaseResponse<int>>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;

        public CreateLoanCommandHandler(ILoanRepository loanRepository, IUserRepository userRepository, IBookRepository bookRepository)
        {
            _loanRepository = loanRepository;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }

        public async Task<BaseResponse<int>> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.IdBook);
            if (book == null || !book.Active)
            {
                return BaseResponse<int>.Failure("Livro não encontrado ou inativo");
            }

            var user = await _userRepository.GetByIdAsync(request.IdUser);
            if (user == null || !user.Active)
            {
                return BaseResponse<int>.Failure("Usuário não encontrado ou inativo");
            }

            var loanExists = await _loanRepository.GetActiveByBookId(book.Id);
            if(loanExists != null)
            {
                return BaseResponse<int>.Failure($"Este livro já esta emprestado! previsão de retorno: {loanExists.ReturnDate}");
            }

            var loan = new Loan(request.IdUser, request.IdBook, request.ExpectedReturnDate, request.LoanDate);

            await _loanRepository.AddAsync(loan);

            book.isAvailable(false, request.LoanDate);
            await _bookRepository.UpdateAsync(book);

            return BaseResponse<int>.Success(loan.Id);
        }

    }
}
