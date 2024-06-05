using Library.Application.ViewModels;
using Library.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.GetAllWaitLists
{
    public class GetAllWaitListQueryHandler : IRequestHandler<GetAllWaitListQuery, BaseResponse<List<WaitListViewModel>>>
    {
        private readonly IWaitListRepository _waitListRepository;

        public GetAllWaitListQueryHandler(IWaitListRepository waitListRepository)
        {
            _waitListRepository = waitListRepository;
        }

        public async Task<BaseResponse<List<WaitListViewModel>>> Handle(GetAllWaitListQuery request, CancellationToken cancellationToken)
        {
            var waitLists = await _waitListRepository.GetAllAsyncWithUserandBook();

            var waitListViewModel = waitLists.Select(
                                    l => new WaitListViewModel(l.Id, l.Book.Title, l.User.Email)).ToList();

            return BaseResponse<List<WaitListViewModel>>.Success(waitListViewModel);
        }
    }
}
