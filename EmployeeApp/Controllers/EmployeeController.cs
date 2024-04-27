using EmployeeApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers
{
    public class EmployeeController : Controller
    {
        #region Employees Table
        public IActionResult Index()=> View(Employee.GetEmployees());
        #endregion
        #region Create New Employee
        public IActionResult Create()
        {
            ViewBag.Departments = Department.GetDepartments();
            var newEmployee = new Employee();
            return View("Form", newEmployee);
        }
        [HttpPost]
        public IActionResult Create(Employee newEmployee)
        {
            ModelState.Remove("EmployeeNumber");
            if (newEmployee.DepartmentId != null && Department.FindDepartmentById(newEmployee.DepartmentId) != null) ModelState.Remove("Department");
            if (ModelState.IsValid)
            {
                newEmployee.Create();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = Department.GetDepartments();
            ViewBag.hasErrors = true;
            return View("Form", newEmployee);
        }
        #endregion
        #region Edit Employee
        public IActionResult Edit(string num)
        {
            ViewBag.Departments = Department.GetDepartments();
            return View("Form", Employee.FindByNumber(num));
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (employee.DepartmentId != null && Department.FindDepartmentById(employee.DepartmentId) != null) ModelState.Remove("Department");
            if (ModelState.IsValid)
            {
                employee.Update();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = Department.GetDepartments();
            ViewBag.hasErrors = true;
            return View("Form", employee);
        }

        #endregion
        #region Delete Employee
        public IActionResult Delete(string num)
        {
            Employee.Delete(num);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
