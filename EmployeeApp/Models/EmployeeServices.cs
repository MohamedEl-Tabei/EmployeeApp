namespace EmployeeApp.Models
{
    public partial class Employee
    {
        static AppDbContext dbContext = new AppDbContext();
        public static Employee findByNumber(string num)=>dbContext.Employees.ToList().FirstOrDefault(employee => employee.EmployeeNumber == num);
        public void generateEmployeeNumber()
        {
            string maxEmpNumber =dbContext.Employees.Max(employee=>employee.EmployeeNumber);
            decimal number = Convert.ToDecimal(maxEmpNumber) + 1;
            string empNumber = number.ToString();
            while (empNumber.Length < 5)
            {
                empNumber = "0" + empNumber;
            }
            this.EmployeeNumber= empNumber;
        }
       
    }
}
