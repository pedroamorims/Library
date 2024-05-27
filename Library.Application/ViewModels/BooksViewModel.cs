namespace Library.Application.ViewModels
{
    public class BooksViewModel
    {
        public BooksViewModel(int id, string title, string author)
        {
            Id = id;
            Title = title;
            Author = author;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
    }
}
