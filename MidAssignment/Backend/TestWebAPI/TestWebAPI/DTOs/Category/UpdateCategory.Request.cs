using System.ComponentModel.DataAnnotations;

namespace TestWebAPI.DTOs.Category
{
    public class UpdateCategoryRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
