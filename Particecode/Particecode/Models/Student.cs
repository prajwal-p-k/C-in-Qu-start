using Particecode.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Student
{
    [Key]
    public int StudentId { get; set; } // Updated property name
    [Required]
    public string StudentName { get; set; }
    public string Address { get; set; }
    public long Mobile { get; set; }

    [ForeignKey("Subject")]
    public int SubjectId { get; set; } // Updated foreign key name

    public virtual Subject Subject { get; set; }
}
