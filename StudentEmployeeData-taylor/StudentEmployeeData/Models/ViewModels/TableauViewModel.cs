using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEmployeeData.Models.ViewModels
{
    public class TableauViewModel
    {
        public IQueryable<Employee> Employees { get; set; }
    }
}
