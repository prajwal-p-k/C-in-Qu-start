using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual List<Book> Books { get; set; }
    }
}
