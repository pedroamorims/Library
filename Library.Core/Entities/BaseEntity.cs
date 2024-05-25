namespace Library.Core.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            CreationDate = DateTime.Now;
            Active = true;
        }

        public int Id { get; private set; }

        public DateTime CreationDate { get; private set; }

        public bool Active { get; private set; }

        public void Activate()
        {
            Active = true;
        }

        public void Deactivate()
        {
            Active = false;
        }
    }
}
