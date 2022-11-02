using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEmployeeData.Models.ViewModels
{
    public class NotificationViewModel
    {
        public IQueryable<Notification> Notifications { get; set; }
    }
}
