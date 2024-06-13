using Library.Core.Enums;

namespace Library.Core.Entities
{
    public class WaitList : BaseEntity
    {
        public WaitList(int idUser, int idBook)
        {
            this.IdUser = idUser;
            this.IdBook = idBook;
            Status = WaitListStatusEnum.Created;
        }

        public int IdUser { get; private set; }
        public User User { get; private set; }
        public int IdBook { get; private set; }
        public Book Book { get; private set; }
        public WaitListStatusEnum Status { get; private set; }
        public DateTime? NotifiedAt { get; private set; }
        public void BookAvailable()
        {
            if (Status == WaitListStatusEnum.Created)
            {
                Status = WaitListStatusEnum.PendingNotification;
            }
        }
        public void NotificationSent(DateTime notificationDate)
        {
            if (Status == WaitListStatusEnum.PendingNotification)
            {
                Status = WaitListStatusEnum.NotificationSent;
                NotifiedAt = notificationDate;
            }
        }
        public void Cancel()
        {
            if (Status != WaitListStatusEnum.NotificationSent)
            {
                Status = WaitListStatusEnum.Cancelled;
                Deactivate();
            }
        }
        public void Finish()
        {
            Status = WaitListStatusEnum.Finished;
        }




    }
}
