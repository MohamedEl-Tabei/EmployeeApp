using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EmployeeApp.Models
{
    [Table("Employee")]
    public partial class Employee
    {
        #region Employee Id
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Employee Id")]
        public int EmployeeId { get; set; }
        #endregion
        #region Employee Name
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 10)]
        [Display(Name = "Employee Name")]
        [Column(TypeName = "VARCHAR(50)")]
        public string EmployeeName { get; set; }
        #endregion
        #region Employee Number
        [Required]
        [StringLength(10)]
        [Display(Name = "Employee Number")]
        [Column(TypeName = "VARCHAR(10)")]
        public string EmployeeNumber { get; set; }
        #endregion
        #region Employee Date Of Birth
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        public DateOnly DateOfBirth { get; set; }
        #endregion
        #region Employee Date Of Joining
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Joining")]
        public DateOnly DateOfJoining { get; set; }
        #endregion
        #region Employee Gross Salary
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Employee Gross Salary")]
        [Column(TypeName = "DECIMAL(12,2)")]
        public decimal EmployeeGrossSalary { get; set; }
        #endregion
        #region Employee Net Salary
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "DECIMAL(12,2)")]
        [Display(Name = "Employee Net Salary")]
        public decimal EmployeeNetSalary { get; set; }
        #endregion
        #region Department Id
        [Required]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        #endregion
        #region Department
        public virtual Department Department { get; set; }
        #endregion
        public Employee()
        {
            
            EmployeeNumber = "00002";
            var today = DateOnly.FromDateTime(DateTime.Now);
            DateOfBirth=today;
            DateOfJoining=today;
        }
    }
}
