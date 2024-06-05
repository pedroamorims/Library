using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<BaseResponse<int>>
    {
        public CreateUserCommand(string fullName, string email, string password, string role)
        {
            FullName = fullName;
            Email = email;
            Password = password;
            Role = role;
        }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
