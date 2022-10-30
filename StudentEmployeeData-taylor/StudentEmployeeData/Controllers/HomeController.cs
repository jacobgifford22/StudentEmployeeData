using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using StudentEmployeeData.Models;
using StudentEmployeeData.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEmployeeData.Controllers
{
    public class HomeController : Controller
    {
        private IStudentEmployeeDataRepository _repo { get; set; }

        public HomeController(IStudentEmployeeDataRepository temp)
        {
            _repo = temp;
        }

        [HttpGet]
        public IActionResult ViewEmployees()
        {
            var x = new EmployeesViewModel
            {
                Employees = _repo.Employees
            };

            return View(x);
        }

        [HttpGet]
        public IActionResult ViewTableau()
        {
            var x = new TableauViewModel
            {
                Employees = _repo.Employees
            };

            return View(x);
        }

        [HttpGet]
        public IActionResult EmployeeDetails(int employeeId)
        {
            Employee employee = _repo.Employees.Where(x => x.EmployeeId == employeeId).Single();

            return View(employee);
        }

    }
}
