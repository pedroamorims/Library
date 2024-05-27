using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, string password, string role)
        {
            FullName = fullName;
            Email = email;
            Loans = new();
            Password = password;
            Role = role;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Password {  get; private set; }
        public string Role { get; private set; }
        public List<Loan> Loans {get ; private set;}
    }
}
