using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CellRepository.Domain.Entities.Utils
{
    public abstract class Valuent
    {
        [NotMapped]
        public Dictionary<int, PropertyMessage> NotificationsList { get; private set; }

        public abstract bool Validate();

        /// <summary>
        /// Pushs a new notification to the top of the list
        /// </summary>
        /// <param name="property">Property field of the class</param>
        /// <param name="message">Validation message with some usefull information</param>

        public void AddNotification(string property, string message)
        {
            var currentId = NotificationsList?.Count ?? 0;

            PropertyMessage notificationAddToList = new (message, property);

            NotificationsList.Add(currentId, notificationAddToList);
        }

        /// <summary>
        /// Checks before if the class model it's okay
        /// </summary>
        /// <returns></returns>

        public bool IsOkay()
        {
            if (NotificationsList?.Count > 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Only gets the first validation
        /// </summary>
        /// <returns></returns>
        public PropertyMessage GetFirstValidation()
        {
            if (NotificationsList.Count == 0)
                return null;

            return NotificationsList.FirstOrDefault().Value;
        }


        /// <summary>
        /// Instead of returning a PropertyMessage model u get a string 
        /// with the full message specification
        /// </summary>
        /// <returns></returns>
        public string GetFirstValidationMessage()
        {
            var message = GetFirstValidation();

            var fullMessage = message.Property + " - " + message.Message;

            return fullMessage;
        }

        /// <summary>
        /// Return all the validation
        /// for example u can use to send information to the front
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PropertyMessage> ReturnValidations()
        {
            List<PropertyMessage> NotificationsListWithoutId = new();

            foreach (var notification in NotificationsList)
            {
                NotificationsListWithoutId.Add(notification.Value);
            }

            return NotificationsListWithoutId.AsReadOnly();
        }
    }
}