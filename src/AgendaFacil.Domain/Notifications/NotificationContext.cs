using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaFacil.Domain.Notifications
{
    public class NotificationContext
    {
        private readonly List<Notification> _notifications = new List<Notification>();

        public bool HasNotifications => _notifications.Any();

        public IReadOnlyList<Notification> Notifications => _notifications;

        public void AddNotification(string property, string message)
        {
            _notifications.Add(new Notification(property, message));
        }

        public void AddNotifications(IEnumerable<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }
    }
}
