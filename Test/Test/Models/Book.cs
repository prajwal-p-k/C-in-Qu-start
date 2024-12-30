using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        [MaxLength(200)] // Optional: Specifies the max length for the column
        public string BookName { get; set; }

        [Required]
        public string BookAuthor { get; set; }

        [ForeignKey("Category")]
        public int BookCategoryId { get; set; }

        [ForeignKey("Publisher")]
        public int BookPublishedId { get; set; }

        public string BookPublishedYear { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal BookPrice { get; set; }

        // Navigation properties
        public virtual Category Category { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
