using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private INotificationRepository _notificationRepo { get; set; }
        private IStudentEmployeeDataRepository _employeeRepo { get; set; }

        public NotificationsController(INotificationRepository tempNotification, IStudentEmployeeDataRepository tempEmployee)
        {
            _notificationRepo = tempNotification;
            _employeeRepo = tempEmployee;
            
        }

        [HttpGet]
        public IActionResult NotificationDetails()
        {
            var x = new NotificationViewModel
            {
                Notifications = _notificationRepo.Notifications
            };

            return View(x);
        }

        public IActionResult RefreshNotifications()
        {
            int numNotifications = _notificationRepo.Notifications.Count();

            if (numNotifications > 0)
            {
                return RedirectToAction("NotificationDetails");
            }
            else
            {
                var employees = new EmployeesViewModel
                {
                    Employees = _employeeRepo.Employees
                };

                //E-form submission notification
                foreach (var item in employees.Employees)
                {
                    if ((item.SubmittedEForm == "no") && (DateTime.Today > Convert.ToDateTime(item.EFormSubmissionDate).AddDays(7)))
                    {
                        _notificationRepo.AddNotification(new Notification
                        {
                            Type = "E-form Not Submitted",
                            Message = "This student has not submitted their e-form.",
                            EmployeeId = item.EmployeeId
                        });
                    }
                }

                // increase pay rate notification
                foreach (var item in employees.Employees)
                {
                    if (DateTime.Today > Convert.ToDateTime(item.IncreaseInputDate).AddMonths(4))
                    {
                        _notificationRepo.AddNotification(new Notification
                        {
                            Type = "Pay Increase",
                            Message = "Increase pay rate.",
                            EmployeeId = item.EmployeeId
                        });
                    }
                }

                //Authorized to work notification
                foreach (var item in employees.Employees)
                {
                    if ((item.AuthorizationToWorkReceived == "No") && (DateTime.Today > Convert.ToDateTime(item.AuthorizationToWorkEmailSentDate).AddDays(7)))
                    {
                        _notificationRepo.AddNotification(new Notification
                        {
                            Type = "Authorization to Work",
                            Message = "Reminder to follow up with student about authorization to work.",
                            EmployeeId = item.EmployeeId
                        });
                    }
                }

                return RedirectToAction("NotificationDetails");
            }
        }

        public IActionResult Delete(int notificationId)
        {
            var notification = _notificationRepo.Notifications.Single(x => x.NotificationId == notificationId);

            _notificationRepo.DeleteNotification(notification);

            return RedirectToAction("NotificationDetails");
        }

        public IActionResult DeleteAllNotifications()
        {
            IQueryable<Notification> notifications = _notificationRepo.Notifications;

            _notificationRepo.DeleteAllNotifications(notifications);

            return RedirectToAction("NotificationDetails");
        }
    }
}
