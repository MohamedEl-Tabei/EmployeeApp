using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApp.Models.Departments
{
    [Table("Department")]
    public partial class Department
    {
        #region Department Id
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="Department Id")]
        public int DepartmentId { get; set; }
        #endregion
        #region Department Name
        [Required]
        [StringLength(maximumLength:150,MinimumLength =3)]
        [Column(TypeName ="VARCHAR(150)")]
        [Display(Name ="Department Name")]
        public string DepartmentName { get; set; }
        #endregion
    }
}
