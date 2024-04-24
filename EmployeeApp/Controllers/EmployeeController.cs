using EmployeeApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers
{
    public class EmployeeController : Controller
    {
        static AppDbContext dbContext = new AppDbContext();
        public IActionResult Index()
        {
            List<Employee> employees=dbContext.Employees.ToList();
            return View(employees);
        }
        public IActionResult Create()
        {
            ViewBag.Departments=dbContext.Departments;
            var newEmployee = new Employee();
            return View("Form",newEmployee);
        }
        public IActionResult Edit(string num)
        {
            ViewBag.Departments = dbContext.Departments;
            Employee employee =Employee.findByNumber(num);
            return View("Form",employee);
        }
    }
}
