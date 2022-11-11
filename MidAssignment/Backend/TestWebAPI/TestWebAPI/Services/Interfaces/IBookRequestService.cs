using TestWebAPI.DTOs.BookRequest;

namespace TestWebAPI.Services.Interfaces
{
    public interface IBookRequestService
    {
        CreateBookRequestResponse? Create(CreateBookRequestRequest addModel);
        IEnumerable<GetBookRequest> GetAll();
        GetBookRequest? GetById(int id);
        ApprovalBookRequestResponse? Approval(int id, ApprovalBookRequestRequest requestModel);
    }
}
