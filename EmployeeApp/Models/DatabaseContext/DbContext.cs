using Microsoft.EntityFrameworkCore;
using EmployeeApp.Models.Departments;
using EmployeeApp.Models.Employees;
using EmployeeApp.Environment;
namespace EmployeeApp.Models.DatabaseContext
{
    public class AppDbContext:DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(EnvironmentData.ConnectionString);
        }
    }
}
