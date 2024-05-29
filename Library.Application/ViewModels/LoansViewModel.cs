using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.ViewModels
{
    public class LoansViewModel
    {
        public LoansViewModel(int id, string bookName, string userMail, DateTime loanDate, DateTime returnDate)
        {
            Id = id;
            BookName = bookName;
            UserMail = userMail;
            LoanDate = loanDate;
            ReturnDate = returnDate;
        }

        public int Id { get; private set; }
        public string BookName { get; private set; }
        public string UserMail { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime ReturnDate { get; private set; }
    }
}
