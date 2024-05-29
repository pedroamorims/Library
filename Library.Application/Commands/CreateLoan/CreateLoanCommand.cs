using Library.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.CreateLoan
{
    public class CreateLoanCommand : IRequest<int>
    {
        public CreateLoanCommand(int idUser, int idBook, DateTime expectedReturnDate, DateTime loanDate)
        {
            IdUser = idUser;
            IdBook = idBook;
            ExpectedReturnDate = expectedReturnDate;
            LoanDate = loanDate;
        }

        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime LoanDate { get; set; }
    }
}
