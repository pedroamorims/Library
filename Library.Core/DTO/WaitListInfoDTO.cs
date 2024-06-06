using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.DTO
{
    public class WaitListInfoDTO
    {
        public WaitListInfoDTO(int id, string bookName, string userMail)
        {
            Id = id;
            BookName = bookName;
            UserMail = userMail;
        }

        public int Id { get; private set; }
        public string BookName { get; private set; }
        public string UserMail { get; private set; }
    }
}
