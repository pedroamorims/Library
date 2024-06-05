using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Enums
{
    public enum WaitListStatusEnum
    {
        Created = 0,
        PendingNotification = 1,
        NotificationSent = 2,
        Cancelled = 3,
        Finished = 4
    }
}
