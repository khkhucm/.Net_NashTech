using TestWebAPI.DTOs.Book;

namespace TestWebAPI.DTOs.Category
{
    public class GetCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<BookModel>? Books { get; set; }
    }
}
