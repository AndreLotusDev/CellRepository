using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CellRepository.Domain.Entities
{
    public abstract class Valuent
    {
        [NotMapped]
        public Dictionary<int, Dictionary<string, string>> NotificationsList { get; private set; }

        public Valuent()
        {

        }

        public void AddNotification(string property, string message)
        {
            var currentId = NotificationsList?.Count ?? 0;

            var notificationAddToList = new Dictionary<string, string>();
            notificationAddToList.Add(property, message);

            NotificationsList.Add(currentId, notificationAddToList);
        }

        public bool IsOkay()
        {
            if (NotificationsList?.Count > 0)
            {
                return false;
            }

            return true;
        }

        public Dictionary<string, string> ReturnValidations()
        {
            Dictionary<string, string> NotificationsListWithoutId = new();

            foreach (var notification in NotificationsList)
            {
                NotificationsListWithoutId = notification.Value;
            }

            return NotificationsListWithoutId;
        }
    }
}