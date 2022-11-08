using TestWebAPI.DTOs.Category;

namespace TestWebAPI.DTOs.Book
{
    public class UpdateBookResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public CategoryModel? Category { get; set; }
    }
}
