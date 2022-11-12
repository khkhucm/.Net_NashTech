using Common.Enums;
using Test.Data.Entities;
using Test.Data.Repositories.Interfaces;
using TestWebAPI.DTOs.BookRequest;
using TestWebAPI.DTOs.User;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Services.Implements
{
    public class BookRequestService : IBookRequestService
    {
        private readonly IBookRequestRepository _bookRequestRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;
        public BookRequestService(IBookRequestRepository bookRequestRepository, IBookRepository bookRepository, IUserRepository userRepository)
        {
            _bookRequestRepository = bookRequestRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        public ApprovalBookRequestResponse? Approval(int id, ApprovalBookRequestRequest requestModel, UserModel approver)
        {
            using var transaction = _bookRequestRepository.DatabaseTransaction();

            try
            {
                var user = _userRepository.Get(u => u.Id == approver.Id);

                var borrowingRequest = _bookRequestRepository.Get(br => br.RequestId == id);

                if (borrowingRequest != null && borrowingRequest.Status == RequestBookStatus.Waiting)
                {
                    borrowingRequest.Status = requestModel.Status;
                    borrowingRequest.ApprovalModifiedByUser = user;
                    borrowingRequest.ApprovalById = user?.Id;
                    borrowingRequest.UserId = 1;

                    _bookRequestRepository.Update(borrowingRequest);
                    _bookRequestRepository.SaveChanges();
                    transaction.Commit();

                    return new ApprovalBookRequestResponse(borrowingRequest);
                }

                return null;
            }
            catch
            {
                transaction.RollBack();

                return null;
            }
        }

        public CreateBookRequestResponse? Create(CreateBookRequestRequest addModel, UserModel requester)
        {
            using var transaction = _bookRequestRepository.DatabaseTransaction();

            try
            {
                var books = _bookRepository.GetAll(b => addModel.BookIds.Contains(b.BookId));

                if (books != null && addModel.BookIds.Count != 0)
                {
                    var bookRequestDetails = books.Select(entity => new BookRequestDetail
                    {
                        BookId = entity.BookId,
                    }).ToList();

                    var newBookRequest = new BookRequest
                    {
                        UserId = requester.Id,
                        RequestedDate = DateTime.Now,
                        BookRequestDetails = bookRequestDetails,
                    };

                    _bookRequestRepository.Create(newBookRequest);
                    _bookRequestRepository.SaveChanges();
                    transaction.Commit();

                    return new CreateBookRequestResponse(newBookRequest);
                }
                else
                {
                    transaction.RollBack();

                    return null;
                }
            }
            catch
            {
                transaction.RollBack();

                return null;
            }
        }

        public IEnumerable<GetBookRequest> GetAll()
        {
            var listBookRequests = _bookRequestRepository.GetAll();

            return listBookRequests.Select(entity => new GetBookRequest(entity));
        }

        public GetBookRequest? GetById(int id)
        {
            var bookRequest = _bookRequestRepository.Get(br => br.RequestId == id);

            if (bookRequest == null)
            {
                return null;
            }

            return new GetBookRequest(bookRequest);
        }
    }
}
