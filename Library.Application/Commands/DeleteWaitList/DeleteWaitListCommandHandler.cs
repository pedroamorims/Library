using Library.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.DeleteWaitList
{
    public class DeleteWaitListCommandHandler : IRequestHandler<DeleteWaitListCommand, Unit>
    {
        private readonly IWaitListRepository _waitListRepository;

        public DeleteWaitListCommandHandler(IWaitListRepository waitListRepository)
        {
            _waitListRepository = waitListRepository;
        }

        public async Task<Unit> Handle(DeleteWaitListCommand request, CancellationToken cancellationToken)
        {
            var waitList = await _waitListRepository.GetById(request.Id);

            waitList?.Cancel();

            await _waitListRepository.SaveChangesAsync();

            return Unit.Value;

        }
    }
}
