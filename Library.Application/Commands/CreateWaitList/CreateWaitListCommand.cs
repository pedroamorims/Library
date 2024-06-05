using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.CreateWaitList
{
    public class CreateWaitListCommand : IRequest<BaseResponse<int>>
    {
        public CreateWaitListCommand(int idUser, int idBook)
        {
            IdUser = idUser;
            IdBook = idBook;
        }

        public int IdUser { get; set; }
        public int IdBook { get; set; }

    }
}
