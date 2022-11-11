using TestWebAPI.DTOs.BookRequestDetail;

namespace TestWebAPI.DTOs.BookRequest
{
    public class ApprovalBookRequestResponse
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int RequestedUserId { get; set; }
        public DateTime? RequestedDate { get; set; }
        public IEnumerable<BookRequestDetailModel?> BookRequestDetails { get; set; }

        public ApprovalBookRequestResponse(Test.Data.Entities.BookRequest request)
        {
            Id = request.RequestId;
            Status = request.Status.ToString();
            RequestedUserId = request.UserId;
            RequestedDate = request.RequestedDate;
            BookRequestDetails = request.BookRequestDetails.Select(entity => new BookRequestDetailModel
            {
                Id = request.RequestId,
                BookId = entity.BookId,
                Status = entity.Status.ToString()
            });
        }
    }
}
