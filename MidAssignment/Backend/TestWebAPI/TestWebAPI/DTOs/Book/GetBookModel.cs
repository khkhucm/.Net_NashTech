using TestWebAPI.DTOs.Category;

namespace TestWebAPI.DTOs.Book
{
    public class GetBookModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public CategoryModel? Category { get; set; }
    }
}
