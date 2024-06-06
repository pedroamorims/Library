namespace Library.Core.Entities
{
    public class Loan : BaseEntity
    {
        public Loan(int idUser, int idBook, DateTime expectedReturnDate, DateTime loanDate)
        {
            this.IdUser = idUser;
            this.IdBook = idBook;
            this.ExpectedReturnDate = expectedReturnDate;
            this.LoanDate = loanDate;
        }

        public int IdUser { get; private set; }
        public User User { get; private set; }
        public int IdBook { get; private set; }
        public Book Book { get; private set; }
        public DateTime ExpectedReturnDate { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime ReturnDate { get; private set; }    
        
        public void Return(DateTime returnDate)
        {
            ReturnDate = returnDate;
            Deactivate();
        }

    }
}
