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

        public IActionResult Index()
        {
            var x = new EmployeesViewModel
            {
                Employees = _repo.Employees
            };

            return View(x);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
