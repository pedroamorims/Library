using Library.Core.DTO;
using Library.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Library.Infraestructure
{
    public class NotificationService : INotificationService
    {
        private readonly IMessageBusService _messageBusService;
        private const string QUEUE_NAME = "WaitList";

        public NotificationService(IMessageBusService messageBusService)
        {
            _messageBusService = messageBusService;
        }

        public void NotifyBookAvailable(WaitListInfoDTO waitListInfoDTO)
        {
            var waitListInfoJson = JsonSerializer.Serialize(waitListInfoDTO);

            var waitListInfoBytes = Encoding.UTF8.GetBytes(waitListInfoJson);

            _messageBusService.Publish(QUEUE_NAME, waitListInfoBytes);
        }
    }
}
