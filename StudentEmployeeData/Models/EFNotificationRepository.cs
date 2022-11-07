using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEmployeeData.Models
{
    public class EFNotificationRepository : INotificationRepository
    {
        private NotificationsDbContext _context { get; set; }

        public EFNotificationRepository(NotificationsDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Notification> Notifications => _context.Notifications;

        public void AddNotification(Notification n)
        {
            _context.Add(n);
            _context.SaveChanges();
        }

        public void DeleteNotification(Notification n)
        {
            _context.Remove(n);
            _context.SaveChanges();
        }

        public void SaveNotification(Notification n)
        {
            _context.Update(n);
            _context.SaveChanges();
        }

        public void DeleteAllNotifications(IQueryable<Notification> notifications)
        {
            foreach (var n in notifications)
            {
                _context.Remove(n);
            }

            _context.SaveChanges();
        }
    }
}