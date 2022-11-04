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
        public IActionResult EmployeeDetails(int employeeId)
        {
            Employee employee = _repo.Employees.Where(x => x.EmployeeId == employeeId).Single();

            return View(employee);
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee e)
        {
            if (ModelState.IsValid)
            {
                _repo.AddEmployee(e);

                return RedirectToAction("ViewEmployees");
            }
            else
            {
                return View(e);
            }
        }

        [HttpGet]
        public IActionResult Edit(int employeeId)
        {
            var employee = _repo.Employees.Single(x => x.EmployeeId == employeeId);

            return View("Create", employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee e)
        {
            if (ModelState.IsValid)
            {
                _repo.SaveEmployee(e);

                return RedirectToAction("ViewEmployees");
            }
            else
            {
                return RedirectToAction("Edit", new { employeeId = e.EmployeeId });
            }
        }

        [HttpGet]
        public IActionResult Delete(int employeeId)
        {
            var employee = _repo.Employees.Single(x => x.EmployeeId == employeeId);

            return View(employee);
        }

        [HttpPost]
        public IActionResult Delete(Employee e)
        {
            _repo.DeleteEmployee(e);

            return RedirectToAction("ViewEmployees");
        }
    }
}
