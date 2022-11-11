using Common.Enums;

namespace TestWebAPI.DTOs.BookRequestDetail
{
    public class BookRequestDetailModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Status { get; set; }
    }
}
