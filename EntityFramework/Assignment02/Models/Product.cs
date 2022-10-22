using System.ComponentModel.DataAnnotations.Schema;
namespace Assignment02.Models
{
    public class Product
    {
        [Column("ProductId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Category? Category { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string? Manufacture { get; set; }
    }
}