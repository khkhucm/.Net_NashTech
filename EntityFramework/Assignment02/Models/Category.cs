using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment02.Models
{
    public class Category
    {
        [Column("CategoryId")]
        public int Id { get; set; }
        public ICollection<Product> Products { get; set; }
        public string CategoryName { get; set; }
    }
}