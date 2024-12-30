using System.ComponentModel.DataAnnotations;

namespace Practice.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; } // Updated property name
        public string SubjectName { get; set; }
        public virtual List<Student> Students1 { get; set; }
    }
}
