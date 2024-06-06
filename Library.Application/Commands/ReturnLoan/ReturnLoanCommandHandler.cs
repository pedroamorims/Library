using Library.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.ReturnLoan
{
    internal class ReturnLoanCommandHandler : IRequestHandler<ReturnLoanCommand, BaseResponse<string>>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;
        private readonly IWaitListRepository _waitListRepository;

        public ReturnLoanCommandHandler(ILoanRepository loanRepository, IBookRepository bookRepository, IUserRepository userRepository, IWaitListRepository waitListRepository)
        {
            _loanRepository = loanRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            _waitListRepository = waitListRepository;
        }

        public async Task<BaseResponse<string>> Handle(ReturnLoanCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.IdBook);
            if (book == null || !book.Active)
            {
                return BaseResponse<string>.Failure("Livro não encontrado ou inativo");
            }

            var user = await _userRepository.GetByIdAsync(request.IdUser);
            if (user == null || !user.Active)
            {
                return BaseResponse<string>.Failure("Usuário não encontrado ou inativo");
            }

            var loan = await _loanRepository.GetActiveByBookId(book.Id);
            if (loan == null)
            {
                return BaseResponse<string>.Failure($"Empréstimo não localizado");
            }

            loan.Return(request.ReturnDate);

            book.isAvailable(true);

            var waitList = await _waitListRepository.GetAllActivesnotNotifiedWithUserByBookAsync(book.Id);
            if (waitList != null)
            {
                foreach (var item in waitList)
                {
                    item.BookAvailable(); 
                    
                    //Notificar
                }
            }

        }
    }
}
