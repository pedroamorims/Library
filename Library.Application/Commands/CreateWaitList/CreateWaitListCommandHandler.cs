using Library.Core.Entities;
using Library.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.CreateWaitList
{
    internal class CreateWaitListCommandHandler : IRequestHandler<CreateWaitListCommand, BaseResponse<int>>
    {
        private readonly IWaitListRepository _waitListRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILoanRepository _loanRepository;
        public CreateWaitListCommandHandler(IWaitListRepository waitListRepository, IBookRepository bookRepository, IUserRepository userRepository, ILoanRepository loanRepository)
        {
            _waitListRepository = waitListRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            _loanRepository = loanRepository;
        }

        public async Task<BaseResponse<int>> Handle(CreateWaitListCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.IdBook);
            if (book == null || !book.Active)
            {
                return BaseResponse<int>.Failure("Livro não encontrado ou inativo");
            }

            if (book.Available)
            {
                return BaseResponse<int>.Failure("O livro está disponível para empréstimo");
            }

            var user = await _userRepository.GetByIdAsync(request.IdUser);
            if (user == null || !user.Active)
            {
                return BaseResponse<int>.Failure("Usuário não encontrado ou inativo");
            }

            var loanExist = await _loanRepository.GetActiveByUserandBookId(user.Id, book.Id);
            if (loanExist != null)
            {
                return BaseResponse<int>.Failure($"O livro já está com este usuário");
            }

            var waitListExists = await _waitListRepository.GetActiveByUserandBookAsync(user.Id,book.Id);
            if (waitListExists != null)
            {
                return BaseResponse<int>.Failure($"Lista de espera já existe para esse usuário e este livro");
            }

            var waitList = new WaitList(request.IdUser, request.IdBook);

            await _waitListRepository.AddAsync(waitList);

            return BaseResponse<int>.Success(waitList.Id);

        }
    }
}
