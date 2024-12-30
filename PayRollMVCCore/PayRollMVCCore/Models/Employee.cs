using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayRollMVCCore.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
        public string Password { get; set; }
        public string DOB { get; set; }
        public string DOJ { get; set; }

        public decimal Salary { get; set; }
        public string Skillset { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public string Address { get; set; }


        public virtual Department Department { get; set; }
    }
}
