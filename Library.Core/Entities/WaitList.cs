namespace Library.Core.Entities
{
    public class WaitList : BaseEntity
    {
        public WaitList(int idUser, int idBook)
        {
            this.IdUser = idUser;
            this.IdBook = idBook;
        }

        public int IdUser { get; private set; }
        public User User { get; private set; }
        public int IdBook { get; private set; }
        public Book Book { get; private set; }
    }
}
