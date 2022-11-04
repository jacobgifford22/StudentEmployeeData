using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEmployeeData.Models
{
    public class NotificationList
    {
        public List<NotificationItem> Items { get; set; } = new List<NotificationItem>();

        public List<Employee> EmployeeList { get; set; } = new List<Employee>();

        public NotificationList()
        {
            //E-form submission notification
            foreach (var item in EmployeeList)
            {
                if ((item.SubmittedEForm == "no") && (DateTime.Today > Convert.ToDateTime(item.AuthorizationToWorkEmailSentDate).AddDays(7)))
                {
                    Items.Add(new NotificationItem
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
                    Items.Add(new NotificationItem
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
                    Items.Add(new NotificationItem
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

    public class NotificationItem
    {
        [Key]
        [Required]
        public int NotificationItemId { get; set; }
        public string Type { get; set; }  //pay increase, not authorized to work, e-form not submitted
        public string Message { get; set; }
        public int EmployeeId { get; set; }
        public Employee employee { get; set; }
    }
}