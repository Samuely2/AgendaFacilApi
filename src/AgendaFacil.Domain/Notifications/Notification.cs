using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaFacil.Domain.Notifications
{
    public class Notification
    {
        public string Property { get; }
        public string Message { get; }

        public Notification(string property, string message)
        {
            Property = property;
            Message = message;
        }
    }
}
