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
        [BindNever]
        public ICollection<NotificationItem> Item { get; set; }

    }
}
