using Common.Enums;

namespace TestWebAPI.DTOs.BookRequestDetail
{
    public class UpdateBookRequestDetailModel
    {
        public int Id { get; set; }
        //public int BookId { get; set; }
        public RequestBookDetailStatus Status { get; set; }


    }
}
