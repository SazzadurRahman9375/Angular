using R56_M10_Class_06_Work_02.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace R56_M10_Class_06_Work_02.ViewModels
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        [Required, StringLength(50)]
        public string EmployeeName { get; set; } = default!;
        [Required, Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }
        [Required, StringLength(20)]
        public string Phone { get; set; } = default!;
        [Required, EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }
        [Required, Column(TypeName = "money")]
        public decimal Salary { get; set; }

        [Required, ForeignKey("Department")]
        public int DepartmentId { get; set; }
        
        public string DepartmentName { get; set; }=default!;
    }
}
