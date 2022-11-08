using TestWebAPI.DTOs.Category;

namespace TestWebAPI.DTOs.Book
{
    public class UpdateBookRequest
    {
        public string? Name { get; set; }
        public CategoryModel? Category { get; set; }
    }
}
