using Common.Enums;
using System.ComponentModel.DataAnnotations;
using TestWebAPI.DTOs.User;

namespace TestWebAPI.DTOs.BookRequest
{
    public class ApprovalBookRequestRequest
    {
        [Required]
        public RequestBookStatus Status { get; set; }
        //public UserModel? Approver { get; set; }
    }
}
