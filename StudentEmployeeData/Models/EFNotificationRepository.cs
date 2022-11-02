using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEmployeeData.Models
{
    public class EFNotificationRepository : INotificationRepository
    {
        private EmployeeDbContext context { get; set; }

        public EFNotificationRepository (EmployeeDbContext temp)
        {
            context = temp;
        }

        public IQueryable<Notification> Notifications => context.Notifications;

        public void DeleteNotification(Notification n)
        {
            context.Remove(n);
            context.SaveChanges();
        }
    }
}
