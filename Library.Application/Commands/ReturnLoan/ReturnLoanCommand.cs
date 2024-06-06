using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.ReturnLoan
{
    public class ReturnLoanCommand : IRequest<BaseResponse<string>>
    {
        public ReturnLoanCommand(int idUser, int idBook, DateTime returnDate)
        {
            IdUser = idUser;
            IdBook = idBook;
            ReturnDate = returnDate;
        }
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime ReturnDate { get; set; }
    }

}
