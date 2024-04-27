﻿namespace EmployeeApp.Models
{
    public partial class Employee
    {
        static AppDbContext dbContext = new AppDbContext();
        #region Constructors
        public Employee()
        {
            var today=DateOnly.FromDateTime(DateTime.Now);
            DateOfJoining=today;
            DateOfBirth=today;
        }
        #endregion
        #region CRUD
         public static Employee FindByNumber(string num) => dbContext.Employees.ToList().FirstOrDefault(employee => employee.EmployeeNumber == num);

        public static List<Employee> GetEmployees()
        {
            return (from employee in dbContext.Employees
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
                        DepartmentId = employee.DepartmentId,
                        Department = department
                    }).ToList();
        }
        public void Create()
        {
            this.EmployeeNumber=GenerateEmployeeNumber();
            dbContext.Employees.Add(this);
            dbContext.SaveChanges();
        }

        public void Update()
        {
            var employee = FindByNumber(this.EmployeeNumber);
            employee.EmployeeName= this.EmployeeName;
            employee.DateOfBirth= this.DateOfBirth;
            employee.DateOfJoining= this.DateOfJoining;
            employee.DepartmentId= this.DepartmentId;
            employee.EmployeeGrossSalary= this.EmployeeGrossSalary;
            employee.EmployeeNetSalary= this.EmployeeNetSalary;
            dbContext.Employees.Update(employee);
            dbContext.SaveChanges();
        }
        public static void Delete(string num)
        {
            var emp = FindByNumber(num);
            if (emp != null)
            {
                dbContext.Employees.Remove(emp);
                dbContext.SaveChanges();
            }
        }
        #endregion
        #region Private

        private string GenerateEmployeeNumber()
        {
            string maxEmpNumber = dbContext.Employees.Max(employee => employee.EmployeeNumber);
            decimal number = Convert.ToDecimal(maxEmpNumber) + 1;
            string empNumber = number.ToString();
            while (empNumber.Length < 5)
            {
                empNumber = "0" + empNumber;
            }
            return empNumber;
        }
        #endregion

    }
}
