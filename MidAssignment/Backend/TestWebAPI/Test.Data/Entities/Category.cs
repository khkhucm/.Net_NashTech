using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Data.Entities
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
