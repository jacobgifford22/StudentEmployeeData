using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEmployeeData.Models
{
    public interface INotificationRepository
    {
        IQueryable<Notification> Notifications { get; }
    }
}