using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEmployeeData.Models
{
    public class NotificationList
    {
        public List<Notification> Items { get; set; } = new List<Notification>();

        public List<Employee> EmployeeList { get; set; } = new List<Employee>();

        public NotificationList()
        {
            //E-form submission notification
            foreach (var item in EmployeeList)
            {
                if ((item.SubmittedEForm == "no") && (DateTime.Today > Convert.ToDateTime(item.AuthorizationToWorkEmailSentDate).AddDays(7)))
                {
                    Items.Add(new Notification
                    {
                        Type = "E-form not submitted",
                        Message = "This student has not submitted their e-form.",
                        EmployeeId = item.EmployeeId
                    });
                }
            }

            // increase pay rate notification
            foreach (var item in EmployeeList)
            {
                if (DateTime.Today > Convert.ToDateTime(item.IncreaseInputDate).AddMonths(4))
                {
                    Items.Add(new Notification
                    {
                        Type = "Pay Increase",
                        Message = "Increase pay rate.",
                        EmployeeId = item.EmployeeId
                    });
                }
            }

            //Authorized to work notification
            foreach (var item in EmployeeList)
            {
                if ((item.AuthorizationToWorkReceived == "No") && (DateTime.Today > Convert.ToDateTime(item.EFormSubmissionDate).AddDays(7)))
                {
                    Items.Add(new Notification
                    {
                        Type = "Authorization to Work",
                        Message = "Reminder to follow up with student about authorization to work.",
                        EmployeeId = item.EmployeeId
                    });
                }
            }
        }

        /*public virtual void RemoveItem(Project proj)
        {
            Items.RemoveAll(x => x.Project.ProjectId == proj.ProjectId);
        }*/
    }
}