using Library.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<BaseResponse<List<UsersViewModel>>>
    {
    }
}
