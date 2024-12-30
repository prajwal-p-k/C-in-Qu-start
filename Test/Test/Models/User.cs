using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PWD { get; set; }

    }
}
