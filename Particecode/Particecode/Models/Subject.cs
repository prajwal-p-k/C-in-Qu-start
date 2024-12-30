using System.ComponentModel.DataAnnotations;

public class Subject
{
    [Key]
    public int Id { get; set; } // Updated property name
    public string SubjectName { get; set; }
    public virtual List<Student> Students { get; set; }
}
