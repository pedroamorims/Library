namespace Library.Core.Entities
{
    public class Loan : BaseEntity
    {
        public Loan(int idUser, int idBook, DateTime expectedReturnDate, DateTime loanDate)
        {
            this.idUser = idUser;
            this.idBook = idBook;
            this.expectedReturnDate = expectedReturnDate;
            this.loanDate = loanDate;
        }

        public int idUser { get; private set; }
        public int idBook { get; private set; }
        public DateTime expectedReturnDate { get; private set; }
        public DateTime loanDate { get; private set; }
        public DateTime returnDate { get; private set; }


      

    }
}
