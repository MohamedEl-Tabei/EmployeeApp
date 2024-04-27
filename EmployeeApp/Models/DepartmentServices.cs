namespace EmployeeApp.Models
{
    public partial class Department
    {
        static AppDbContext dbContext=new AppDbContext();
        public static List<Department> GetDepartments()=>dbContext.Departments.ToList();
        public static string findNameById(int id)
        {
            var departments = dbContext.Departments.ToList();
            string departmentName = departments.FirstOrDefault(department => department.DepartmentId == id).DepartmentName;
            return departmentName;
        }
        public static Department FindDepartmentById(int id) => dbContext.Departments.SingleOrDefault(department => department.DepartmentId == id);
    }
}
