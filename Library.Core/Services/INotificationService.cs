using Library.Core.DTO;
using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public interface INotificationService
    {
        void NotifyBookAvailable(WaitListInfoDTO waitListInfoDTO);
    }
}
