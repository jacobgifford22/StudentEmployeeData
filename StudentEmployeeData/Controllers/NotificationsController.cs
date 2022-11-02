using Microsoft.AspNetCore.Mvc;
using StudentEmployeeData.Models;
using StudentEmployeeData.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEmployeeData.Controllers
{
    public class NotificationsController : Controller
    {
        private INotificationRepository repo { get; set; }

        public NotificationsController(INotificationRepository temp)
        {
            repo = temp;
        }

        [HttpGet]
        public IActionResult NotificationDetails()
        {
            var x = new NotificationViewModel
            {
                Notifications = repo.Notifications
            };

            return View(x);
        }

        public IActionResult Delete(Notification n)
        {
            repo.DeleteNotification(n);

            return RedirectToAction("NotificationDetails");
        }
    }
}
