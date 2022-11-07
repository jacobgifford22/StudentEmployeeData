using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEmployeeData.Models
{
    public interface INotificationRepository
    {
        IQueryable<Notification> Notifications { get; }

        public void SaveNotification(Notification n);

        public void AddNotification(Notification n);

        public void DeleteNotification(Notification n);

        public void DeleteAllNotifications(IQueryable<Notification> notifications);
    }
}