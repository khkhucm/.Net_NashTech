using TestWebAPI.DTOs.BookRequest;
using TestWebAPI.DTOs.User;

namespace TestWebAPI.Services.Interfaces
{
    public interface IBookRequestService
    {
        CreateBookRequestResponse? Create(CreateBookRequestRequest addModel, UserModel requester);
        IEnumerable<GetBookRequest> GetAll();
        GetBookRequest? GetById(int id);
        ApprovalBookRequestResponse? Approval(int id, ApprovalBookRequestRequest requestModel, UserModel approver);
    }
}
