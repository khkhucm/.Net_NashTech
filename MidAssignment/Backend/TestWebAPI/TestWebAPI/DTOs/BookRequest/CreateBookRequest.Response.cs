
namespace TestWebAPI.DTOs.BookRequest
{
    public class CreateBookRequestResponse
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int RequestedUserId { get; set; }
        public DateTime? RequestedDate { get; set; }

        public CreateBookRequestResponse(Test.Data.Entities.BookRequest request)
        {
            Id = request.RequestId;
            Status = request.Status.ToString();
            RequestedUserId = request.UserId;
            RequestedDate = request.RequestedDate;
        }
    }
}
