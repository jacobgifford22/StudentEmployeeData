using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEmployeeData.Models
{
    public class Notification
    {
        [Key]
        [Required]
        public int NotificationId { get; set; }
        public string Type { get; set; }  //pay increase, not authorized to work, e-form not submitted
        public string Message { get; set; }
        public int EmployeeId { get; set; }
    }
}
