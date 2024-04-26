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
            //List<Employee> employees = dbContext.Employees.ToList();
            List<Employee> employees = (from employee in dbContext.Employees
                                        join department in dbContext.Departments
                                        on employee.DepartmentId equals department.DepartmentId
                                        select new Employee
                                        {
                                            EmployeeId = employee.EmployeeId,
                                            EmployeeName = employee.EmployeeName,
                                            EmployeeGrossSalary = employee.EmployeeGrossSalary,
                                            EmployeeNetSalary = employee.EmployeeNetSalary,
                                            EmployeeNumber = employee.EmployeeNumber,
                                            DateOfBirth = employee.DateOfBirth,
                                            DateOfJoining = employee.DateOfJoining,
                                            DepartmentId = department.DepartmentId,
                                            Department = department,
                                        }).ToList();
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
            ModelState.Remove("EmployeeNumber");
            if (newEmployee.DepartmentId != null && Department.findDepartmentById(newEmployee.DepartmentId) != null) ModelState.Remove("Department");
            if (ModelState.IsValid)
            {
                newEmployee.generateEmployeeNumber();
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
            return View("Form", Employee.findByNumber(num));
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            //ModelState.Remove("EmployeeNumber");
            if (employee.DepartmentId != null && Department.findDepartmentById(employee.DepartmentId) != null) ModelState.Remove("Department");
            if (ModelState.IsValid)
            {
                dbContext.Employees.Update(employee);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = dbContext.Departments;
            ViewBag.hasErrors = true;
            return View("Form", employee);
        }

        #endregion
        #region Delete Employee
        public IActionResult Delete(string num)
        {
            Employee emp = Employee.findByNumber(num);
            if(emp!=null)
            {
                dbContext.Employees.Remove(emp);
                dbContext.SaveChanges();
            }
            var employees = (from employee in dbContext.Employees
                             join department in dbContext.Departments on employee.DepartmentId equals department.DepartmentId
                             select new Employee
                             {
                                 Department = department,
                                 EmployeeId = employee.EmployeeId,
                                 EmployeeGrossSalary = employee.EmployeeGrossSalary,
                                 EmployeeName = employee.EmployeeName,
                                 EmployeeNetSalary = employee.EmployeeNetSalary,
                                 EmployeeNumber = employee.EmployeeNumber,
                                 DateOfBirth = employee.DateOfBirth,
                                 DateOfJoining = employee.DateOfJoining,
                                 DepartmentId = employee.DepartmentId,
                             }
                             ).ToList();
            return View("Index", employees);
        }
        #endregion
    }
}
