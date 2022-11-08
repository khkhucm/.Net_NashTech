using System.ComponentModel.DataAnnotations;

namespace TestWebAPI.DTOs.Book
{
    public class CreateBookRequest
    {
        [Required] 
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
