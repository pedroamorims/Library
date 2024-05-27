using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.ViewModels
{
    public class UsersViewModel
    {
        public UsersViewModel(int id, string fullName, string email)
        {
            FullName = fullName;
            Email = email;
            Id = id;
        }

        public int Id { get; set; }
        public string FullName { get; set; }

        public string Email { get; set; }
    }
}
