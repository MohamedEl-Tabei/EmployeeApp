namespace EmployeeApp.Models
{
    public partial class Employee
    {
        static AppDbContext dbContext = new AppDbContext();
        public static Employee findByNumber(string num)
        {
            Employee employee = dbContext.Employees.ToList().FirstOrDefault(employee => employee.EmployeeNumber == num);
            return employee;
        }
    }
}
