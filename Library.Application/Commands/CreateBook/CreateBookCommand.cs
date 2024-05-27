using Library.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<int>
    {
        public CreateBookCommand(string title, string author, string iSBN, int publicationYear)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            PublicationYear = publicationYear;
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int PublicationYear { get; set; }

    }
}
