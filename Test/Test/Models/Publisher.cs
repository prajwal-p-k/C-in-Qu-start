using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public string Address { get; set; }

        public virtual List<Book> Books { get; set; }
    }
}
