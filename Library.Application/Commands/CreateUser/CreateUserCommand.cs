using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public CreateUserCommand(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }

        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
