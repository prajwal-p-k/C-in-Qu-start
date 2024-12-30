using System.ComponentModel.DataAnnotations;

namespace PayRollMVCCore.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string DepartmentName { get; set; }

        public virtual List<Employee> Employees {set;get;}
        

    }
}
