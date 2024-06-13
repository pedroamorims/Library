using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.DeleteWaitList
{
    public class DeleteWaitListCommand : IRequest<Unit>
    {
        public DeleteWaitListCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
