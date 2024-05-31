namespace Library.Application.ViewModels
{
    public class BooksViewModel
    {
        public BooksViewModel(int id, string title, string author, bool active)
        {
            Id = id;
            Title = title;
            Author = author;
            Active = active;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public bool Active { get; private set; }
    }
}
