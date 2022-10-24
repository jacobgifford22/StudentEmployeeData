using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEmployeeData.Models
{
    public interface IStudentEmployeeDataRepository
    {
        IQueryable<Employee> Employees { get; }

        public void SaveEmployee(Employee e);

        public void AddEmployee(Employee e);

        public void DeleteEmployee(Employee e);
    }
}
