using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEmployeeData.Models
{
    public class EFStudentEmployeeDataRepository : IStudentEmployeeDataRepository
    {
        private EmployeeDbContext _context { get; set; }

        public EFStudentEmployeeDataRepository(EmployeeDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Employee> Employees => _context.Employees;

        public void AddEmployee(Employee e)
        {
            _context.Add(e);
            _context.SaveChanges();
        }

        public void DeleteEmployee(Employee e)
        {
            _context.Remove(e);
            _context.SaveChanges();
        }

        public void SaveEmployee(Employee e)
        {
            _context.Update(e);
            _context.SaveChanges();
        }
    }
}
