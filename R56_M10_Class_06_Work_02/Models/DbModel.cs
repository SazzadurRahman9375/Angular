using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace R56_M10_Class_06_Work_02.Models
{
    public enum Gender { Male = 1, Female }
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required, StringLength(50)]
        public string DepartmentName { get; set; } = default!;
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
    public class Employee
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
        public virtual Department? Department { get; set; }
    }
    

    public class EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : DbContext(options)
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "Admin" },
                new Department { DepartmentId = 2, DepartmentName = "HR" },
                new Department { DepartmentId = 3, DepartmentName = "Accounts" }
                );
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, EmployeeName = "Robin", Gender = Gender.Male, Phone = "016XXXXXXXX", Salary = 25000, BirthDate = DateTime.Parse("1996-11-6"), DepartmentId = 1 },
                 new Employee { EmployeeId = 2, EmployeeName = "Fahad", Gender = Gender.Male, Phone = "017XXXXXXXX", Salary = 35000, BirthDate = DateTime.Parse("1997-8-3"),  DepartmentId = 2 },
                  new Employee { EmployeeId = 3, EmployeeName = "Shila", Gender = Gender.Female, Phone = "018XXXXXXXX", Salary = 50000, BirthDate = DateTime.Parse("1998-5-6"),  DepartmentId = 3 }
                );
        }
    }
}
