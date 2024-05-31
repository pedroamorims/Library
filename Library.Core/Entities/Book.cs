using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Entities
{
    public class Book : BaseEntity
    {
        public Book(string title, string author, string iSBN, int publicationYear)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            PublicationYear = publicationYear;
            Loans = new();
            Available = true;
        }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public bool Available { get; private set; }
        public int PublicationYear { get; private set; }
        public DateTime? LastLoanDate { get; private set; }
        public List<Loan> Loans { get; private set; }
        public List<WaitList> WaitLists { get; private set; }

        public void isAvailable(bool available, DateTime? loanDate = null)
        {
            Available = available;

            if (!available)
            {
                LastLoanDate = loanDate;
            }
        }



    }
}
