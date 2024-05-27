using Library.Application.ViewModels;
using Library.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.GetAllUsers
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUsersQuery, List<UsersViewModel>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UsersViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();

            var usersViewModel = users
                .Select(u => new UsersViewModel(u.Id, u.FullName, u.Email))
                .ToList();

            return usersViewModel;
        }
    }
}
