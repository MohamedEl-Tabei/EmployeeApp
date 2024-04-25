using EmployeeApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers
{
    public class EmployeeController : Controller
    {
        static AppDbContext dbContext = new AppDbContext();
        #region Employees Table
        public IActionResult Index()
        {
            List<Employee> employees = dbContext.Employees.ToList();
            return View(employees);
        }
        #endregion

        #region Create New Employee
        public IActionResult Create()
        {
            ViewBag.Departments = dbContext.Departments;
            var newEmployee = new Employee();
            return View("Form", newEmployee);
        }
        [HttpPost]
        public IActionResult Create(Employee newEmployee)
        {
            if (newEmployee.DepartmentId != null && Department.findDepartmentById(newEmployee.DepartmentId) != null) ModelState.Remove("Department");
            if (ModelState.IsValid)
            {
                dbContext.Employees.Add(newEmployee);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = dbContext.Departments;
            ViewBag.hasErrors = true;
            return View("Form", newEmployee);
        }
        #endregion

        #region Edit Employee
        public IActionResult Edit(string num)
        {
            ViewBag.Departments = dbContext.Departments;
            Employee employee = Employee.findByNumber(num);
            return View("Form", employee);
        }
        #endregion
    }
}
