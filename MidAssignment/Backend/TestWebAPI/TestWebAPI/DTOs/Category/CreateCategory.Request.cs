using System.ComponentModel.DataAnnotations;

namespace TestWebAPI.DTOs.Category
{
    public class CreateCategoryRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
